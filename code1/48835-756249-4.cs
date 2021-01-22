    public class MyClass
    {
       public event EventHandler Loading;
       public event EventHandler Finished;
    
       protected virtual void OnLoading(EventArgs e)
       {
           EventHandler handler = Loading;
           if( handler != null )
           {
               handler(this, e);
           }
       }
    
       protected virtual void OnFinished(EventArgs e)
       {
           EventHandler handler = Finished;
           if( handler != null )
           {
               handler(this, e);
           }
       }
    }
