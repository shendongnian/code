       class Program {
          static void Main(string[] args)
          {
             List<int> ints = new List<int>();
             List<int> ints2 = new List<int>();
             List<int> ints3 = new List<int>();
             for (int i = 0; i < 5; ++i) ints.Add(i);
             for (int j = 0; j < 5; ++j) ints2.Add(j);
             for (int k = 0; k < 3; ++k) ints2.Add(k);
              List<ICollection<int>> rets = GetRefs<int>(3, ints, ints2, ints3);
              Console.WriteLine(string.Format("{0} out of {1} collections contain a reference to {2}", rets.Count, rets.Capacity, 3));
              Console.ReadKey();
          }
          public static List<ICollection<T>> GetRefs<T>(T o, params ICollection<T>[] collections)
          {
             List<ICollection<T>> ret = new List<ICollection<T>>(collections.Length);
             foreach (ICollection<T> obj in collections)
             {
                if (obj.Contains(o)) ret.Add(obj);
             }
             return ret;
          }}
