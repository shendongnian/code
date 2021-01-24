    public class Person
    {
        private int _age = 0;
        public int Age { get => _age;  }
        public string Name { get; set; }
    
        public void Birthday()
        {
            _age += 1;
        }
    }
