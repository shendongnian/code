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
      static class MyExtensions
      {
        static readonly Random Random = new Random();
        public static void Shuffle<T>(this IList<T> list)
        {
          int n = list.Count;
          while (n > 1)
          {
            n--;
            int k = Random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
          }
        }
      }
    }
