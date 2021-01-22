    public class SuperClassEmptyCtor
    {
        public SuperClassEmptyCtor()
        {
            // Default Ctor
        }
    }
    public class SubClassA : SuperClassEmptyCtor
    {
        // No Ctor's this is fine since we have
        // a default (empty ctor in the base)
    }
    public class SuperClassCtor
    {
        public SuperClassCtor(string value)
        {
            // Default Ctor
        }
    }
    public class SubClassB : SuperClassCtor
    {
        // This fails because we need to satisfy
        // the ctor for the base class.
    }
    public class SubClassC : SuperClassCtor
    {
        public SubClassC(string value) : base(value)
        {
            // make it easy and pipe the params
            // straight to the base!
        }
    }
