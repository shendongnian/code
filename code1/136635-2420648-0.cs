    class Parent
    {
        public virtual string DoSomething()
        {
            return "ParentField";
        }
    }
    
    class Child
    {
        public override string DoSomething()
        {
             return "ChildField";
        }
    }
