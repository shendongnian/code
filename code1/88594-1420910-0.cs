    public class ClassA
    {
        public string ProcessName{ get; private set;}
        public ClassA()
        {
            ProcessName = "ClassAProcess";
        }
        public ClassA(string processName)
        {
            ProcessName = processName;
        }
    }
    public class ClassB : ClassA
    {
        public ClassB() : base("ClassAProcess")
        {
        }
    }
