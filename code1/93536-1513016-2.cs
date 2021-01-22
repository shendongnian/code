    public class SomeClass
    {
        public bool IsValid(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
    
            return input.Length > 5;
        }
        public void SomeNewMethod() {  }
    }
    
