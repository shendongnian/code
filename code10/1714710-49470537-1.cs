    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    
    public class WaitForSecondsExample : MonoBehaviour
    {
    
        public Text m_MyText;
        public Text OtherText;
    	
    	
        void Start()
        {
            StartCoroutine(Example());
        }
    
        IEnumerator Example()
        {
            m_MyText.text = "There was once a mother and her child";
    		m_MyText.text = "The mother loved her child very dearly";
            yield return new WaitForSeconds(3); //return must be at the end since every piece of code after return is inaccessible code
        }
    }
