    class Person
    {
        private string _FirstName = "Joe";
        private string _LastName = "Smith";
        private int _Age = 18;
        private const int MinAge = 1;
        private const int MaxAge = 99;
        public Person()
        {
        }
        public Person(string FirstName, string LastName, int Age)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
        }
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }
        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                if (IsValidAge(value))
                    throw new ArgumentOutOfRangeException("value","Please enter a positive age less than 100.");
                else
                    _Age = Convert.ToInt32(value);
            }
        }
        private bool IsValidAge(int age)
        {
            return (age < MinAge || age > MaxAge);
        }
    
        public override string ToString()
        {
            if (Age == 1) 
                return "My name is " + FirstName + " " + LastName + " and I am " + Age + " year old.";
            else
                return "My name is " + FirstName + " " + LastName + " and I am " + Age + " years old.";
        }  
    }
    static void Main(string[] args)
        {
            Person him, her;
            try
            {
                him = new Person("Joe Bob", "McGruff", 1);
                Console.WriteLine(him);
            }
            catch (ArgumentOutOfRangeException range)
            {
                Console.WriteLine(range.Message);
            }
            try
            {
                her = new Person();
                her.Age = -5;
                Console.WriteLine(her);
            }
            catch (ArgumentOutOfRangeException range)
            {
                Console.Write(range.Message);
            }
            Console.ReadKey();
        }
