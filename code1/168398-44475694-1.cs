    public class Child
    {
        public string name { get; set; }
        public int age { get; set; }
    }
    
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public string city { get; set; }
        public List<Child> Childs { get; set; }
    }
