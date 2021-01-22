    class A{
          public static void Main()
          {
           byte[] a = new byte[]{143,147,31,70,195,72,228,190,152,222,65,240,152,183,0,161};
           string s = System.Convert.ToBase64String(a);
           System.Console.WriteLine(s);
           byte[] b = System.Convert.FromBase64String(s);
           System.Console.Write("[");
           foreach (var n in b)
               System.Console.Write(n+",");
           System.Console.WriteLine("]");
          }
    }
