    public class Test
    {
    
      private PrivateMembers Members { get; set; }
    
      public object Foo
      {
        get
        {
          return Members.Foo;
        }
        set
        {
          Members.Foo = value;
          // Do something else here.
        }
      }
    
      private class PrivateMembers
      {
        public object Foo { get; set; }
      }
    }
