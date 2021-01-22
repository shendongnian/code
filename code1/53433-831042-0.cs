    public class MyTask
    {
       string _a;
       int _b;
       int _c;
       float _d;
    
       public event EventHandler Finished;
       public MyTask( string a, int b, int c, float d )
       {
          _a = a;
          _b = b;
          _c = c;
          _d = d;
       }
    
       public void DoWork()
       {
           Thread t = new Thread(new ThreadStart(DoWorkCore));
           t.Start();
       }
    
       private void DoWorkCore()
       {
          // do some stuff
          OnFinished();
       }
       protected virtual void OnFinished()
       {
          // raise finished in a threadsafe way 
       }
    }
