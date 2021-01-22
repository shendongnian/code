    public abstract class MyDelegateObject : MarshalByRefObject
    {
       public void EventHandlerCallback( object sender, EventArgs e )
       {
          EventHandlerCallbackCore(sender, e);
       }
    
       protected abstract void EventHandlerCallbackCore(object sender, EventArgs e );
    
       public override object InitializeLifetimeService() { return null; }
    }
