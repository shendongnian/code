    public class Foo
    {
       protected static Bar CreateBarInstance()
       {
          return new Bar();
       }
       public virtual Bar CreateBar()
       {
          return CreateBarInstance();
       }
    }
    public class Bar
    {
        internal Bar()
        {
        }
    }
    public class Baz : Foo
    {
        public override Bar CreateBar()
        {
            Bar b = base.CreateBar();
            // manipulate the Bar in some fashion
            return b;
        }
    }
