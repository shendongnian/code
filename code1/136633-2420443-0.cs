    class Parent
    {
        protected virtual string MyField() { return "ParentField"; }
    
        public virtual string DoSomething()
        {
            return MyField();
        }
    }
    
    class Child : Parent
    {
        protected override string MyField() { return "ChildField"; }
    } 
