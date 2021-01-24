    public class Multi : Benchmark<List<Tuple<double, double, double, double, double, double>>, int>
    {
       protected override int InternalRun()
       {
          int i = 0;
          foreach (var item in Input)
             if (item.Item1 > item.Item2)
                if (item.Item3 < item.Item4)
                   if (item.Item5 == item.Item6)
                      i++;
          return i;
       }    
    }
