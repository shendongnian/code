    public class BaseFieldValue<T>
    {
        public BaseFieldValue()
        {
            //...
        } 
        
        public BaseFieldValue(T value) 
        {
            //however many things you need to test for here
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
