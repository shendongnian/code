    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>
            {
                new Item{
                    Id = 1,
                    MyProperty = "Propr1",
                    Deleted = 0
                },
                new Item{
                    Id = 1,
                    MyProperty = "Propr2",
                    Deleted = 1
                },
                new Item{
                    Id = 2,
                    MyProperty = "Prop3",
                    Deleted = 0
                },
                new Item{
                    Id = 3,
                    MyProperty = "Propr4",
                    Deleted = 0
                },
                  new Item{
                    Id = 3,
                    MyProperty = "Prop5",
                    Deleted = 1
                }
            };
            foreach (IGrouping<int,Item> group in items.GroupBy(x => x.Id).ToList())
            {
                List<Item> groupItems = group.ToList();
                Item deletedItem = groupItems.Where(x => x.Deleted == 1).FirstOrDefault();
                if(deletedItem != null)
                {
                    deletedItem.MyProperty = string.Join(",", groupItems.Select(x => x.MyProperty).ToArray());
                    Console.WriteLine(deletedItem.Id);
                    Console.WriteLine(deletedItem.MyProperty);
                }
            }
        }
    }
    class Item
    {
        public int Id { get; set; }
        public string MyProperty { get; set; }
        public int Deleted { get; set; }
    }
