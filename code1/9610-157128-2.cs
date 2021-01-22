    public class FatherProp
    {
    }
    public class ChildPropProp: FatherProp
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
                return new ChildProp();
            }
        }
    }
