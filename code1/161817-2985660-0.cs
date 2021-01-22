    // target.exe code
    namespace Target {
       public class MyConfig { }
       
       public class Program {
          static void Main(string[] args) { }
          public static void EntryPoint(MyConfig conf) { }
       }
    }
    // source.exe code
    namespace Source {
       class Program {
          static void Main(string[] args) {
             Target.MyConfig conf = new Target.Config();
             Target.Program.EntryPoint(conf);
          }
       }
    }
