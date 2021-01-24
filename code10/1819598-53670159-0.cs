    public class Property
    {
        public string PropReference{get;set;}
    }
    public class Calculation
    {
        public string Operator{get;set;}
    }
    
    public class Calculation
    {
        public Property Prop {get;set;}
        public Calculation Calc {get;set;}
        public Property Prop2 {get;set;}
    }
