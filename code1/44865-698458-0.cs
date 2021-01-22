    public class MyUserControl1 : UserControl
    {
      public void Init(...)
      {
        var uc2 = new MyUserControl2(this);
      }
    }
    
    public class MyUserControl2 : UserControl
    {
      private MyUserControl1 parentUserControl;
    
      public MyUserControl2(MyUserControl1 parent)
      {
        this.parentUserControl = parent;
      }
    }
