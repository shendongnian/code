    public interface IMyROClass
    {
        string name { get; }
    }
    
    public class MyROClass : IMyROClass
    {
        private string _name;
        public string name { get { return _name; } }
        public MyROClass(string name) { _name = name; }
    }
    public class MyClass
    { 
        private readonly MyROClass _myROClass; 
        public MyClass(MyROClass myROClass) { _myROClass = myROClass; } 
        public IMyROClass myROClass => _myROClass;
    } 
