     class Program
    {
        private static void Main(string[] args)
        {
            var items = new List<Item>();
            items.Add(new Item {Id = 1, Name = "Item1"});
            items.Add(new Item {Id = 2, Name = "Item2"});
            items.Add(new Item {Id = 3, Name = "Item3"});
            
            //Duplicate item
            items.Add(new Item {Id = 4, Name = "Item4"});
            //Duplicate item
            items.Add(new Item {Id = 2, Name = "Item2"});
            items.Add(new Item {Id = 3, Name = "Item3"});
            var res = items.Select(i => new {i.Id, i.Name})
                .Distinct().Select(x => new Item {Id = x.Id, Name = x.Name}).ToList();
            // now res contains distinct records
        }
    }
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
