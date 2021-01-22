    using System.Linq;
    class Program
    {
       static void Main()
       {
          var array = new int[] { 1, 2, 2, 3 };
          var distinctArray = array.Distinct().ToArray();
       }
    }
