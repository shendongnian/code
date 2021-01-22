    public class Person
    {
        private int _age;
        private int x;
        public int Age
        {
            get { return _age; }
            set 
            { 
                _age = value;
                x = _age;
            }
        }
     }
