    public class Foo
    {
      public Foo(ICOMObject obj)
      {
        obj.Changed += OnChanged;
      }
      private void OnChanged(object arg)
      {
      }
    }
