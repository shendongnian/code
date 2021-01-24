    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Points : MonoBehaviour {
        void OnGUI()
        {
            int score = ExampleClass.playerScore;
            GUIStyle style = new GUIStyle(GUI.skin.button);
            style.fontSize = 24;
            GUI.Label(new Rect(1, 1, 150, 30), score.ToString() + " points", style);
        }
    }
