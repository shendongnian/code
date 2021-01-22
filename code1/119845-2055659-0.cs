    public class AsyncHandler : IHttpAsyncHandler
    { 
      public void ProcessRequest(HttpContext ctx)
      {
        // not used
      }
    
      public bool IsReusable
      {
        get { return false;}
      }
    
      public IAsyncResult BeginProcessRequest(HttpContext ctx, 
                                              AsyncCallback cb, 
                                              object obj)
      {
        AsyncRequestState reqState = 
                          new AsyncRequestState(ctx, cb, obj);
        AsyncRequest ar = new AsyncRequest(reqState);
        ThreadStart ts = new ThreadStart(ar.ProcessRequest);
        Thread t = new Thread(ts);
        t.Start();
      
        return reqState;
      }
    
      public void EndProcessRequest(IAsyncResult ar)
      {
        AsyncRequestState ars = ar as AsyncRequestState;
        if (ars != null)
        {
         // here you could perform some cleanup, write something else to the
         // Response, or whatever else you need to do
        }
      }
    }
    
    public class AsyncRequest
    {
      private AsyncRequestState _asyncRequestState;
    
      public AsyncRequest(AsyncRequestState ars)
      {
        _asyncRequestState = ars;
      }
        
      public void ProcessRequest()
      {
        MyFunctions.CalculateTotal(int a, int b);
    
        // tell asp.net I am finished processing this request
        _asyncRequestState.CompleteRequest();
      }
    }
