    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class CenterName : MonoBehaviour {
        public Text text;
        public List<string> storyText;
    
        // Use this for initialization
        IEnumerator Start () {
            foreach (string sz in storyText)
            {
                text.text = sz;
                yield return new WaitForSeconds(3);
            }
        }
    }
