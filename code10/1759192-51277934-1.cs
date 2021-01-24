    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class CustomText : MonoBehaviour
    {
        public string toBeSearched;
        public Text textField;
        private string defaultValue;
        private void Start()
        {
            defaultValue = textField.text;
            GenerateRandomHour();
        }
    
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GenerateRandomHour();
            }
        }
    
        private void GenerateRandomHour()
        {
            string numberName = Random.Range(1, 10).ToString();
            textField.text = string.Format(defaultValue, numberName);
        }
    }
