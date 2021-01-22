    public class Person
    {
        private int _id;
    
        public int Id
        {
            get
            {
                // Do some logic or call a method here
                return _id;
            }
            set
            {
                if(value <= 0)
                    throw new CustomInvalidValueException();
                
                _id = value;
            }
        }
    }
