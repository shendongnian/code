    namespace extension
    {
     public class ext
     {
     public static List<double> clone(this List<double> t)
            {
                List<double> kop = new List<double>();
                int x;
                for (x = 0; x < t.Count; x++)
                {
                    kop.Add(t[x]);
                }
                return kop;
            }
       };
    
    }
