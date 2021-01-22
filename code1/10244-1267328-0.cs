    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections;
    
    namespace Test
    {
      class Program
      {
        static void Main(string[] args)
        {
          var test = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
          var result = test.Split(7);
          int cnt = 0;
    
          foreach (IEnumerable<int> chunk in result)
          {
            cnt = chunk.Count();
            Console.WriteLine(cnt);
          }
          cnt = result.Count();
          Console.WriteLine(cnt);
          Console.ReadLine();
        }
      }
    
      static class LinqExt
      {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int chunkLength)
        {
          if (chunkLength <= 0)
            throw new ArgumentOutOfRangeException("chunkLength", "chunkLength must be greater than 0");
    
          IEnumerable<T> result = null;
          using (IEnumerator<T> enumerator = source.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              result = GetChunk(enumerator, chunkLength);
              yield return result;
            }
          }
        }
    
        static IEnumerable<T> GetChunk<T>(IEnumerator<T> source, int chunkLength)
        {
          int x = chunkLength;
          do
            yield return source.Current;
          while (--x > 0 && source.MoveNext());
        }
      }
    }
