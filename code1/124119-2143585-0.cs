    class Foo
    {
         public event EventHandler PerformAction;
         
         private void OnActionNeeded()
         {
              // A bunch of Bars need to do something important now.
    
              if (PerformAction != null)
                     PerformAction.Invoke();
         }
    
    }
    
    class Bar
    {
       public Bar(Foo fooToWatch)
       {
             fooToWatch.PerformAction += new EventHandler(Foo_PerformAction);
       }
    
       void Foo_PerformAction(object sender, EventArgs e)
       {
            // Do that voodoo that you do here.
       }
    }
