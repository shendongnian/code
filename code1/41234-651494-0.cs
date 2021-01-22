    public abstract class LabFileBase
    {
        public string LabFileObjectType { get; }
        public string ID {get;set;}
        public string Name {get;set;}
    }
    public class Sample1 : LabFileBase
    {    
        public string LabFileObjectType { get { return "Sample1"; } }
        //..
    }
    
    public class Sample2 : LabFileBase
    {    
        public string LabFileObjectType { get { return "Sample2"; } }
        //..
    }
