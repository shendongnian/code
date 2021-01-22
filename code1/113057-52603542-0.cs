    public class OrigType{
        public string Prop1A {get;set;}
        public string Prop1B {get;set;}
    }
    public class TargetType{
        public string Prop2A {get;set;}
        public string Prop2B {get;set;}
    }
    var list1 = new List<OrigType>();
    var list2 = new List<TargetType>();
    list1.ConvertAll(x => new OrigType { Prop2A = x.Prop1A, Prop2B = x.Prop1B })
