        using System.IO;
        using System.Reflection;
        namespace TestHelpers {
          public class ClassHelpers {
            public static string PathToBin() {
              return Path.GetDirectoryName(
                       Assembly.GetExecutingAssembly().GetName().CodeBase);
            }
          }
        }
