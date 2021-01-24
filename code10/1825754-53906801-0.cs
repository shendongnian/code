    public class Person
    {
        public string _name;
        public Person(string name)
        {
            _name = name;
        }
        public void TellMyName()
        {
            Console.WriteLine(_name);
        }
    }
    // ...
    var o = new Person("John");
    var p = (Action)o.TellMyName;
    p();
