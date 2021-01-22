    public class Comparer : IComparer<string> {
    
       private Dictionary<string, int> _order;
    
       public Comparer() {
          _order = new Dictionary<string, int>();
          _order.Add("03-33", 1);
          _order.Add("01-11", 2);
          _order.Add("02-22", 3);
       }
    
       public int Compare(string x, string y) {
          return _order[x.Substring(2, 5)].CompareTo(_order[y.Substring(2, 5)]);
       }
    
    }
