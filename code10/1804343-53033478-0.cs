    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Cube : MonoBehaviour {
         private static Color color1;
         private static Color color2;
         private static bool hasColorsAssigned = false;
         private static string lastColor;
         // Use this for initialization
         void Start () {
             if (hasColorsAssigned == false)
             {
                 color1 = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                 color2 = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                 hasColorsAssigned = true;
             }
             if (lastColor == "color1")
             {
                 GetComponent<Renderer>().material.color = color2;
                 lastColor = "color2";
             }
             else
             {
                 GetComponent<Renderer>().material.color = color1;
                 lastColor = "color1";
             }
         }
         // Update is called once per frame
         void Update () {
		
	     }
     }
