    class Program
    {
        private static Random random = new Random();
        static void Main(string[] args)
        {
            //GENERATES A RANDOM LIST FOR THE EXAMPLE
            List<Item> items = new List<Item>();
            int? lastID = null;
            for(int i = 0; i < 100; i++)
            {
                int id = random.Next();
                items.Add(new Item() { ID = id, NextItemID = lastID });
                lastID = id;
            }
            //GENERATES A RANDOM LIST FOR THE EXAMPLE
            items.OrderByNextItemID(); //SORTS THE LIST BY NextItemID
        }
    }
    public static class Extensions
    {
        public static void OrderByNextItemID(this List<Item> items)
        {
            List<Item> results = new List<Item>();
            Item item = items.Where(x => x.NextItemID == null).First();
            results.Add(item);
            items.Remove(item);
            int length = items.Count;
            for(int i = 0; i < length; i++)
            {
                item = items.Where(x => x.NextItemID == results.Last().ID).FirstOrDefault();
                if(item != null)
                {
                    results.Add(item);
                    items.Remove(item);
                }
            }
            results.Reverse();
            items.AddRange(results);
        }
    }
    public class Item
    {
        public int ID { get; set; }
        public int? NextItemID { get; set; }
    }
