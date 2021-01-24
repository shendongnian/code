    [Serializable]
    public class TheTypeToBeCached
    {
       public OneSubType Property1 {get;set;}
       public SecondSubType Property2 {get;set;}
    }
    [Serializable]
    public class OneSubType 
    {
        public ThirdSubType Property3 {get;set;}
        public ForthSubType Property4 {get;set;}
        public AnotherSubType Property5 {get;set;}
    }
    [Serializable]
    public class SecondSubType
    {
        public ForthSubType Property6 {get;set;}
        public AnotherSubType Property7 {get;set;}
    }
    [Serializable]
    public class ThridSubType
    {
        public SecondSubType Property8{get;set;}
    }
    [Serializable]
    public class ForthSubType
    {
        public SecondSubType Property9{get;set;}
    }
    [Serializable]
    public class AnotherSubType
    {
        public OneSubType Property10{get;set;}
    }
