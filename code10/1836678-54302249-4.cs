    public class Example : MonoBehaviour
    {
        // Reference those in the inspector via drag and drop
        public InputField Textfield1;
        public InputField Textfield2;
        
        public void DevideByTen()
        {
            float num1;
    
            // Tries to parse the inserted string value into a float value
            // if wrong input or bad format this returns 0 instead of throwing an exception
            float.TryParse(Textfield1.text, num1);
    
            // if instead you prefer to explicitly throw an exception 
            // you could do something like
            try
            {
                num1 = float.Parse(Textfield1.text);
            }
            catch(Exception e)
            {
                Debug.LogWarningFormat(this, "Could not parse input: \"{0}\"", Textfield1.text);
                Debug.LogException(e);
                return;
            }
        
            // Devide by 10
            var devided = num1 / 10.0f;
        
            // Set the result of the deviding as text to Textfield2
            Textfield2.text = devided.ToString();
        }
    }
