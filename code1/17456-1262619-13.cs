    using System;
    using System.Collections.Generic;
    namespace SimpleLottery
    {
      class Program
      {
        private static void Main(string[] args)
        {
          var numbers = new List<int>();
          for (int i = 1; i <= 75; i++)
            numbers.Add(i);
          numbers.Shuffle();
          Console.WriteLine("The winning numbers are: {0}", string.Join(",  ", numbers.GetRange(0, 5)));
        }
      }
      public static class ThreadSafeRandom
      {
          private static readonly Random Global = new Random();
          [ThreadStatic] private static Random Local;
          public static Random ThisThreadsRandom
          {
              get { return Local ?? (Local = new Random(Global.Next())); }
          }
      }
      static class MyExtensions
      {
        public static void Shuffle<T>(this IList<T> list)
        {
          int n = list.Count;
          while (n > 1)
          {
            n--;
            int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
          }
        }
      }
    }
