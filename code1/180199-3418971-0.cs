    class Base {
        public virtual void DoMethod() {...}
    }
    class Level1 : Base {
        public override void DoMethod() {...}
    }
    // etc..
    
    foreach(Base o in oList)
    {
        o.DoMethod();
    }
