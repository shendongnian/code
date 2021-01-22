    namespace MyApplication
    {
        public class AppController
        {
            static AppController _AppController;
    
             //Constructor
             public void AppController()
             {
                 //Do what you will here, Start login form, bind events, w.e :)
             }
    
             static AppController Instance
             {
                get
                {
                     if(_AppController == null)
                     {
                         _AppController = new AppController();
                     }
                     return _AppController;
                }
             }
        }
    }
