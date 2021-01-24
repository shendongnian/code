    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class TextChangeScript : MonoBehaviour
    {
        public Text m_MyText;
        public List<string> storyText;
        IEnumerator StoryText() {
            foreach (string sz in storyText)
            {
                text.text = sz;
                yield return new WaitForSeconds(3); // in 3 seconds. execution will begin here and iterate to the next string in the storyText.  
            }
        }
        void Start()
        {
            StartCoroutine(StoryText());
        }
    
        void Update()
        {
    
        }
    }
