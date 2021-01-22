    public class Interval {DateTime Start; DateTime End;}
    public static IEnumerable<Interval> Intervals(this IEnumerable<DateTime> source)
    {
        DateTime last;
        bool firstFlag = true;
        foreach( DateTime current in source)
        {
           if (firstFlag)
           {
              last = current;
              firstFlag = false;
              continue;
           }
    
           yield return new Interval {Start = last, End = current};
           last = current;
        }
    }
