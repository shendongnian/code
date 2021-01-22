    public class ClassA
    {
        public ClassA(string someString) { }
    }
    
    public class ClassB : ClassA
    {
        public ClassB(string someString) : base(someString == null  ? "" :  someString.ToLower()) { }
    }
