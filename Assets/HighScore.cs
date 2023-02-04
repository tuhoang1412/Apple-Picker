using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private int _SCORE = 100;

    private Text txtCom;
    void Awake () {
        _UI_TEXT = GetComponent<Text>();
        if (PlayerPrefs.HasKey("HighScore")) {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", SCORE);
        ResetScore();
    }
    static public int SCORE {
        get { return _SCORE; }
        private set {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            if ( _UI_TEXT != null ) {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }
    static public void TRY_SET_HIGH_SCORE( int scoreToTry ) {
        if ( scoreToTry <= SCORE ) return;
        SCORE = scoreToTry;
    }

    [Tooltip( "Check this box to reset the HighScore")]
    public bool resetHighScoreNow = false;

    void ResetScore() {
        if ( resetHighScoreNow ) {
            Debug.Log("Reset");
            resetHighScoreNow = false;
            PlayerPrefs.SetInt( "HighScore", 100 );
            Debug.LogWarning( "PlayerPrefs HighScore reset");
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
