     public static class ext{
                public static string[] twodim(this string[,] inarr, int row) {
                    string[] ret = new string[inarr.GetLength(1)];
                    for (int i = 0; i < inarr.GetLength(1); i++)
                        ret[i] = inarr[row, i];
                    return ret;
                }
            }
     public class Program{
           static void dump(string name, string[] arr){
               Console.WriteLine(name);
               for (int i = 0; i < arr.Length; i++)
                   Console.WriteLine("  {0}  ", arr[i]);
           }
      static void Main(string[] args){
         string[,] table = new string[,] {
                {"Apple", "Banana", "Clementine", "Damson"},
                {"Elderberry", "Fig", "Grape", "Huckleberry"},
                {"Indian Prune", "Jujube", "Kiwi", "Lime"}
            };
    
         dump("Row 0", table.twodim(0));
        dump("Row 0", table.twodim(1));
    dump("Row 0", table.twodim(2));
    
      }
