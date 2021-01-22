    public static void Main()
    {
      var parent = new Parent();
      parent.CreateChild();
      parent.DestroyChild();
      GC.Collect();
      GC.WaitForPendingFinalizers();
    }
    
    public class Child
    {
      public Child(Parent parent)
      {
        parent.Event += this.Handler;
      }
    
      private void Handler(object sender, EventArgs args) { }
    
      ~Child() { Console.WriteLine("disposed"); }
    }
    
    public class Parent
    {
      public event EventHandler Event;
    
      private Child m_Child;
    
      public void CreateChild()
      {
        m_Child = new Child(this);
      }
    
      public void DestroyChild()
      {
        m_Child = null;
      }
    }
