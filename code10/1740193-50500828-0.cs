        protected void Application_BeginRequest()
        {
            SystemReporter.NewRequest();
        }
        public static class SystemReporter
        {   
              static int requestPerMinutesCounter;
          
              public static void NewRequest()
              {
                    requestPerMinutesCounter++;
                    //save it to database 
              }
         }
