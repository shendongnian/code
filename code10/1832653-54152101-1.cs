    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.UI;
    
    public class GetAndSetText : MonoBehaviour
    {
        public InputField name;
        public InputField fname;
        public Text fText;
        public Image boy;
        public Sprite sprite;
    
        public void sum()
        {
            boy = GetComponent<Image>();
    
            if (name.text == "hello") 
            {
                boy.sprite = sprite;
            }
        }
    }
