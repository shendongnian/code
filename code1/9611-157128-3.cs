    public class FatherProp
    {
    }
    public class ChildProp: FatherProp
    {
    }
    public class Father
    {
        public virtual FatherProp SomePropertyName
        {
            get
            {
                return new FatherProp();
            }
        }
    }
    public class Child : Father
    {
        public override FatherProp SomePropertyName
        {
            get
            {
                // override to return a derived type instead
                return new ChildProp();
            }
        }
    }
