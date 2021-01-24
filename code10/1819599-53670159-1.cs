    public class Property
    {
        public string PropReference{get;set;}
    }
    public class Operator
    {
        public string Operator{get;set;}
    }
    
    public class Calculation
    {
        public Property Prop {get;set;}
        public Operator Op {get;set;}
        public Property Prop2 {get;set;}
    }
