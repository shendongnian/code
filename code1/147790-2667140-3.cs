    struct Data {
      public String ProgramName;
      public String Parameters;
    }
    
    class FooRegistry {
      private static Dictionary<String, Data> registry = new Dictionary<String, Data>();
      public static void Register(String key, Data data) {
         FooRegistry.registry[key] = data;
      }
      public static void Get(String key) {
         // Omitted: Check if key exists
         return FooRegistry.registry[key];
      }
    }
