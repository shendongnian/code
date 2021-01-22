    public class Person
    {
        private string name;
        private DateTime dob;
        public Person(string name, DateTime dob)
        {
             this.name = name;
             this.dob = dob;
        }
        public int Age { get { return CalculateAge(this.dob); } }
        public string Name { get { return this.name; } }
        public static int CalculateAge(DateTime dob)
        {
              // use dob to work out age.
        }
    }
