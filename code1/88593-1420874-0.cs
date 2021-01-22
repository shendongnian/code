    public class ClassA
    {
        public virtual string ProcessName { get { return "ClassAProcess"; } }
    } 
    
    public class ClassB : ClassA
    {
        public override string ProcessName { get { return "MyProcess.exe"; } }
    }
