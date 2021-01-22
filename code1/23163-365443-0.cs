        static void Main()
        {
            var list1 = Enumerable.Range(1, 100);
            var list2 = Enumerable.Range(1, 100);
            var qry = from a in list1
                      from b in list2
                      where a % b == 0
                      select new { a, b };
            qry.ToList().ForEach(Console.WriteLine);
        }
