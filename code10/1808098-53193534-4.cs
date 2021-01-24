    public class Parent : IParent
    {
        protected virtual string Suffix => "World";
        public String World => "Hello " + Suffix;
    }
    public class Children : Parent
    {
        protected override string Suffix => "Again";
    }
