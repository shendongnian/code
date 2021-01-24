    public interface IMyROClass
    {
        string name;
    }
    
    public class MyROClass : IMyROClass
    {
        public string name { get; set; }
    }
    public class MyClass
    { 
        private readonly MyROClass _myROClass; 
        public MyClass(MyROClass myROClass) { _myROClass = myROClass; } 
        public IMyROClass myROClass => _myROClass;
    } 
