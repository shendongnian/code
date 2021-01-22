    class MySingleton {
         private static MySingleton instance;
         
         public MySingleton {
              if(instance != null)
                  // One already created, the only call to this
                  // should come through Activator
                  throw...
              instance = this;
         }
         public static MySingleton GetInstance() {
              if(instance == null) instance = new MySingleton();
              return instance;
         }
    }
