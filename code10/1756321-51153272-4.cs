    public class Single : Benchmark<List<Tuple<double, double, double, double, double, double>>, int>
    {
       protected override int InternalRun()
       {
          int i = 0;
          foreach (var item in Input)
             if ((item.Item1 > item.Item2) && (item.Item3 < item.Item4) && (item.Item5 == item.Item6))
                i++;
          return i;
       }
    }
