    class ServiceInterface
    {
         private static ServiceInterface  _instance;
         private ServiceClient _service = new ServiceClient ;
         private ServiceInterface()
         {
           //Prevent accessing default constructor
         }
    
         public static ServiceInterface GetInstance()
         {
    
         if(_instance == null)
    
         {
    
          _instance = new ServiceInterface();
    
        }
    
            return _instance;
    
     
    
     }
    
    
       // You can add your functions to access web service here
    
        Public int PerformTask()
        {
             return _service.PerformTask();
        }
    }
