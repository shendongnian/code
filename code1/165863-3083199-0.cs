    namespace TestProgram {
    
      public static class TestClass {
    
        public static void Test() {
          Console.WriteLine("Success!");
        }
    
      }
    
      class Program {
    
        public static void CallMethod(string name) {
          int pos = name.LastIndexOf('.');
          string className = name.Substring(0, pos);
          string methodName = name.Substring(pos + 1);
          Type.GetType(className).GetMethod(methodName).Invoke(null, null);
        }
    
        static void Main() {
          CallMethod("TestProgram.TestClass.Test");
        }
    
      }
    
    }
