    static void Main(string[] args)
        {
            var coll1 = new List<(int Id, string Name, string Category)>
            {
                (1,"A","AA"),
                (2,"B","BB"),
                (3,"C","CC"),
                (4,"D","DD"),
                (5,"E","EE")
            };
            var coll2 = new List<(int Id, int Order)>
            {
                (5,1),
                (4,2),
                (3,3),
                (2,4),
                (1,5),
                (0,6)
            };
            var sorted = coll1.OrderBy(x => coll2.FirstOrDefault(y => x.Id == y.Id).Order);
            foreach (var item in sorted)
                Console.WriteLine(item);
        }
