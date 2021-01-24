    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class ChangeTextScript : MonoBehaviour {
        public float timeLeft = 5f;
        private Text countdownText; //you can also set Text to public and
                                    // drag the Text object into the inspector field,
                                    // but it's prone to initialization errors when 
                                    // switching scenes or not saving your project
        
        bool shouldBeChangingText = false;
    
        void Start() {
            countdownText = GetComponent<Text>();
        }
    
        public void StartChangingText() {
            shouldBeChangingText = true;
        }
        public void ResetText() {
            shouldBeChangingText = false;
            countdownText.text = "Player left the area";
            timeLeft = 5f;
        }
    
        void Update()
        {
            if (shouldBeChangingText) {
                timeLeft -= Time.deltaTime;
                countdownText.text = ("Time Left = " + timeLeft);
    
                if (timeLeft <= 0)
                {
                    shouldBeChangingText = false;
                    countdownText.text = "You got the cash";
                    timeLeft = 5f;
                }
            }
        }
    }
