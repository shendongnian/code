    public class Foo
    {
      public SomeHandler OnBar;
    
      public void Bar()
      {
         OnBar();  (check for nulls)
         ProtectedBar();
      }
    
      protected virtual ProtectedBar()
      {
      }
    }
