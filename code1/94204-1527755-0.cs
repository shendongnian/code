    using System.Linq;
    using System.Generics;
    public static class Program {
       public static void Main() {
           Console.WriteLine(new List&lt;int&gt; { 1, 2, 3 }.Last()); // outputs - 3
       }
    }
