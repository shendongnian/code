    public class BaseFieldValue<T>
    {
        public BaseFieldValue()
        {
            //...
        } 
        
        public BaseFieldValue(T value) 
        {
            if (typeof(T) == typeof(string))
            {
                SpecialBaseFieldValue(value.ToString());
            }
            else
            {
                //everything else
            }
            //...
        }
    
        private void SpecialBaseFieldValue(string value)
        {
            //...
        }
       
    }
