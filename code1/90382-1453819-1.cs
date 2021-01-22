    public class SomeClass
    {
        private int count;
        public SomeClass()
        {
            count = 0;
        }
        public void Method() 
        {
            // Iterate until this condition is not met.
            if (++count < 100)
            {
                Method();
            }
            else
            {
                count = 0;
            }
        }
    }
