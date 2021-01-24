    public static class Extensions
    {
       public static IEnumerable<decimal> MovingAvg(this IEnumerable<decimal> source, int period)
       {
          var buffer = new Queue<decimal>();
    
          foreach (var value in source)
          {
             buffer.Enqueue(value);
             // sume the buffer for the average at any given time
             yield return buffer.Sum() / buffer.Count;
    
             // Dequeue when needed 
             if (buffer.Count == period)
                buffer.Dequeue();
          }
       }
    }
