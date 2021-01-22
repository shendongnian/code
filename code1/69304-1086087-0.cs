    private delegate T AppServerDelegate<T>();
                
    private T processAppServerRequest<T>(AppServerDelegate<T> delegate_) {
               try{
                  return delegate_();
               }
               catch{
                  //Do a bunch of standard error handling here which will be 
                  //the same for all appserver  calls.
               }
            
            }
            
    //Wrapped public call to AppServer
    public int PostXYZRequest(string requestData1, string requestData2, 
       int pid, DateTime latestRequestTime){
               processAppServerRequest<int>(
                  delegate {
                     return _appSvr.PostXYZRequest(
                        requestData1, 
                        requestData2, 
                        pid, 
                        latestRequestTime);  
                  });
           
