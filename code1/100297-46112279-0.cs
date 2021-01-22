    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class IEnumerableExtensions
    {
      public static IEnumerable<IEnumerable<T>> SplitToChunks<T> (this IEnumerable<T> coll, int chunkSize)
      {
        int skipCount = 0;
        while (coll.Skip (skipCount).Take (chunkSize) is IEnumerable<T> part && part.Any ())
        {
          skipCount += chunkSize;
          yield return part;
        }
      }
    }
    class Program
    {
      static void Main (string[] args)
      {
        var col = Enumerable.Range(1,1<<10);
        var chunks = col.SplitToChunks(8);
        foreach (var c in chunks.Take (200))
        {
          Console.WriteLine (string.Join (" ", c.Select (n => n.ToString ("X4"))));
        }
        Console.WriteLine ();
        Console.WriteLine ();
        "Split this text into parts that are fifteen characters in length, surrounding each part with single quotes and output each into the console on seperate lines."
          .SplitToChunks (15)
          .Select(p => $"'{string.Concat(p)}'")
          .ToList ()
          .ForEach (p => Console.WriteLine (p));
        Console.ReadLine ();
      }
    }
