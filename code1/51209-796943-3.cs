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
           // This code will make sure that you have no IllegalThreadContext
           // exceptions, and will avoid race conditions.
           // note that this won't work in wpf.  You could also take a look
           // at the SynchronizationContext class.
           EventHandler handler = DoSomething;
           if( handler != null )
           {
               ISynchronizeInvoke target = handler.Target as ISynchronizeInvoke;
            
               if( target != null && target.InvokeRequired )
               {
                   target.Invoke (handler, new object[]{this, args});
               }
               else
               {
                    handler(this, args);
               }
           }
       }
    }
