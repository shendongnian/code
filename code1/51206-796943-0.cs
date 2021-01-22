    class MyClass
    {
       public event EventHandler DoSomething;
    
       public void DoWork()
       {
             // do some stuff
            
             // raise the DoSomething event.
             OnDoSomething(EventArgs.Empty);
       }
    
       protected virtual void OnDoSomething(EventArgs args )
       {
           // TODO: make it threadsafe if necessary
           if( DoSomething != null )
               DoSomething(this, args);
       }
    }
