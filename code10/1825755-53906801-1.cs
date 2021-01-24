    public class Person
    {
        public string _name;
        private Person(String name)
        {
            _name = name;
        }
        public static Action Create(string name)
        {
            return new Person(name).TellMyName;
        }
        public void TellMyName()
        {
            Console.WriteLine(_name);
        }
    }
    // ...
    var p = Person.Create("John");
    p();
