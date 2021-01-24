    namespace MyNameSpace {
      ...
      public static class MyEnvironmentVariables {
        // Lazy<int> - let EmployerId be thread safe (and lazy)
        private static Lazy<int> GetEmployeeId = new Lazy<int>(() => {
          //TODO: implement it
          return ObtainEmployeeIdFromDataBase();
        });
    
        public static int EmployeeId {
          get {
            return GetEmployeeId.Value;
          }
        }
      }
