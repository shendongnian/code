    public class Foo
    {
      ICOMObject obj;
      public Foo(ICOMObject obj)
      {
        this.obj = obj;
        this.obj.Changed += OnChanged;
      }
      private void OnChanged(object arg)
      {
      }
    }
