    public Rule
    {
    
       public abstract Eval(ContextData data);
    }
    
    public AndRule
    {
        public Rule Left{get;set;}
        public Rule Right{get;set;}
        public override bool Eval(ContextData data)
        { 
           return Right.Eval(data) && Left.Eval(data);
        }
    }
