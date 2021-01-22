    public class Task
    {
    
         private readonly int _storeId;
         private readonly string _queryObject;
    
         public Task(int storeId, string queryObject)
         {
             _storeId = storeId;
             _queryObject = queryObject;
         }
    
         public void Start()
         {
             Thread t = new Thread (new ThreadStart(DoWork));
             t.Start();
         }
    
         private void DoWork()
         {
             // Do your thing here.
         }
    
    }
