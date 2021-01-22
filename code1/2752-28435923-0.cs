    public static class Extensions { 
        public static String Blank(this String me) {      
          return String.Empty;
        }
        public static T Blank<T>(this T me) {      
          var tot = typeof(T);
          return tot.IsValueType
            ? default(T)
            : (T)Activator.CreateInstance(tot)
            ;
        }
      }
      class Program {
        static void Main(string[] args) {
          Object o = null;
          String s = null;
          int i = 6;
          Console.WriteLine(o.Blank()); //"System.Object"
          Console.WriteLine(s.Blank()); //""
          Console.WriteLine(i.Blank()); //"0"
          Console.ReadKey();
        }
      }
