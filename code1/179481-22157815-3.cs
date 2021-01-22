       static void Main(string[] args)
       {
         var inner = new[] { Tuple.Create(1, "1"), Tuple.Create(2, "2"), Tuple.Create(3, "3") };
         var outer = new[] { Tuple.Create(1, "11"), Tuple.Create(2, "22") };
         var res = outer.LeftJoin(inner, item => item.Item1, item => item.Item1, (it1, it2) =>
         new { Key = it1.Item1, V1 = it1.Item2, V2 = it2 != null ? it2.Item2 : default(string) });
         foreach (var item in res)
           Console.WriteLine(string.Format("{0}, {1}, {2}", item.Key, item.V1, item.V2));
       }
