    public class MyClass
    {
       public event EventHandler Loading;
       public event EventHandler Finished;
    
       protected void OnLoading()
       {
           EventHandler handler = Loading;
           if( handler != null )
           {
               handler(this, EventArgs.Empty);
           }
       }
    
       protected void OnFinished()
       {
           EventHandler handler = Finished;
           if( handler != null )
           {
               handler(this, EventArgs.Empty);
           }
       }
    }
