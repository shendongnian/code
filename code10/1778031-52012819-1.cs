    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    //Make sure that the name fits to the .cs file name and add this script to a GameObejct in the scene
    public class HPsc : MonoBehaviour 
    {
        public static Image HP_Bar_Green;
        public static Image HP_Bar_Red;
    
        //Add your images here in the scene - Inspector:
        public Image imgGreen;
        public Image imgRed;
    
        private void Awake()
        {
            HP_Bar_Green = imgRed; //Make them accessable over the static variables
            HP_Bar_Red = imgGreen;
        }
    
        //Test (also usable in another class):
        private void Start()
        {
            Debug.Log(HPsc.HP_Bar_Red != null);
        }
    }
