    [Serializable, ProtoContract]
    public class ComplexList {
        [ProtoMember(1)]
        public string pubField;
    
        public ComplexList(){}
    }
    
    [Serializable, ProtoContract]
    public class MyClass {
        [ProtoMember(1)]
        public List<ComplexList> ComplexList { get; set; }
    
        public MyClass(){
            ComplexList = new List<ComplexList>();
        }
    
        public void Print(){
            foreach(var x in ComplexList){
                Console.WriteLine(x.pubField);
            }
        }
    }
