    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    public class SetImage : MonoBehaviour {
        public GameObject imageBoy;
        public InputField inputFieldName;
    
	    public void ButtonOnClick()
        {
            if (inputFieldName.text == "boy")
                imageBoy.SetActive(true);
            else
                imageBoy.SetActive(false);
        }
    }
