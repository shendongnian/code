      public static class MyLibraryClass
      {
          public static void Initialize(ServiceHost serviceHost)
          {
            serviceHost.Closed += (...) {
               // Cleanup when host closes.
               Shutdown();
            }
          }
          public static void Shutdown()
          {
              // Cleanup. E.g. stop threads, etc.
          }
       }
