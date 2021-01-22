        class Program
    {
        static void Main(string[] args)
        {
            List<string> blackList = new List<string>(new[] { "jaime", "jhon", "febres", "velez" });
            string inputString = "febres";
            bool result = false;
            blackList.ForEach((item) =>
                                  {
                                      Console.WriteLine("Executing");
                                      if (inputString.Contains(item))
                                      {
                                          result = true;
                                          Console.WriteLine("Founded!");
                                      }
                                  },
                              () => result);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
    public static class MyExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action, Func<bool> breakOn)
        {
            foreach (var item in enumerable)
            {
                action(item);
                if (breakOn())
                {
                    break;
                }
            }
        }
    }
