        protected void Application_BeginRequest()
        {
            SystemReporter.NewRequest();
        }
        public static class SystemReporter
        {   
              static int requestCounter;
          
              public static void NewRequest()
              {
                    requestCounter++;
                    //save it to database 
                    //And other logic for manipulation
              }
         }
