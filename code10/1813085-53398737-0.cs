    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var table1 = new List<Item>
            {
                new Item {Id = 1, Description = "a"},
                new Item {Id = 2, Description = "b"},
                new Item {Id = 3, Description = "c"},
                new Item {Id = 4, Description = "d"}
            };
            var table2 = new List<Item>
            {
                new Item {Id = 1, Description = "e"},
                new Item {Id = 2, Description = "f"},
                new Item {Id = 4, Description = "g"}
            };
            var table3 = new List<Item>
            {
                new Item {Id = 1, Description = "h"},
                new Item {Id = 4, Description = "h"},
                new Item {Id = 5, Description = "i"},
                new Item {Id = 6, Description = "j"}
            };
           
            var leftJoin = from t1 in table1
                join t2 in table2 on t1.Id equals t2.Id into firstJoin
                from x in firstJoin.DefaultIfEmpty()
                join t3 in table3 on x?.Id equals t3.Id into secondJoin
                from y in secondJoin.DefaultIfEmpty()
                select new
                {
                    Table1Id = t1?.Id,
                    Table1Description = t1?.Description,
                    Table2Id = x?.Id,
                    Table2Description = x?.Description,
                    Table3Id =  y?.Id,
                    Table3Description = y?.Description
                };
            Console.WriteLine("Left Join:");
            foreach (var i in leftJoin)
            {
                Console.WriteLine($"T1Id: {i.Table1Id}, T1Desc: {i.Table1Description}, " +
                                  $"T2Id: {i.Table2Id}, T2Desc: {i.Table2Description}, " +
                                  $"T3Id: {i.Table3Id}, T3Desc: {i.Table3Description}");
            }
            Console.WriteLine(string.Empty);
            var grouped = from x in leftJoin
                group x by x.Table3Description
                into group1
                select new
                {
                    Label = group1.Key,
                    Count = group1.Count()
                };
            
            Console.WriteLine("Left Join Grouped:");
            foreach (var i in grouped)
            {
                Console.WriteLine($"Label: {i.Label}, Count: {i.Count}");
            }
            
            Console.ReadLine();
        }
    }
