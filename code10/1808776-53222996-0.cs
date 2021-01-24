        using UnityEngine;
        using UnityEngine.UI;
        
        public class ScalerScript : MonoBehaviour
        {
            public Text text;
        
            public void TextScale(Slider slider)
            {
                text.fontSize = (int)slider.value;
            }
        }
