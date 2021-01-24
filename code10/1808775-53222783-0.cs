        public class slide : MonoBehaviour
        {
            public Text text; // Drag & drop the Text component inside the Inspector
        
            public void ChangeFontSize(float value)
            {    
                ChangeFontSize( Mathf.RoundToInt( value ) ) ;
            }
    
            public void ChangeFontSize(int value)
            {    
                text.fontSize = value;    
            }
        }
