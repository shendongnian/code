    public class Foo
    {
        private int intExample = 0;
        public int IntExample 
        {
            get { return intExample ; }
            set 
            {
                // if the value trying to be set is 5 lower or higher or is 99 call the method
                if((value == intExample - 5) ||
                   (value == intExample + 5) ||
                   (value == 99))
                {
                    DoSomething();
                }
                
                // set the value in the private field
                intExample = value;
            }
        }
        
        private void DoSomething()
        {
            // do something here
        }
    }
