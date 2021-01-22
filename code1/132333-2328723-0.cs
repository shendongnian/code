    class Config { string ClassName; string Namespace; ManagementScope Scope; }
    static class Factory {
         public static readonly Dictionary<Type, Config> Configs = new ...;
         
         static GetInstances(Type requestedType, ...) {
             var config = Configs[requestedType];
             // work with it...
         }
    }
    class AAAAType {
         static AAAAType{
              Factory.Configs.Add(typeof(AAAAType), new Config{ ... });
         }
    }
