    class Program
    {
        static void Main(string[] args)
        {
            Item item = new Item { Name = "Test Item" }; //Create an Item entity
            string jsonItem = Newtonsoft.Json.JsonConvert.SerializeObject(item); //Convert given Item to json
            Item lastItem = Newtonsoft.Json.JsonConvert.DeserializeObject<Item>(jsonItem); //Convert given json in Item
            List<Item> items = new List<Item>()
            {
                new Item { Name ="Test Item 1" },
                new Item { Name ="Test Item 2" },
                new Item { Name ="Test Item 3" },
                new Item { Name ="Test Item 4" },
                new Item { Name ="Test Item 5" }
            }; //Create a list of Item
            string jsonListItems = Newtonsoft.Json.JsonConvert.SerializeObject(items); //Convert given list of Item to json
            List<Item> lastListItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Item>>(jsonListItems); //Convert given json in list of Item
        }
    }
    
    public class Item
    {
        public string Name { get; set; }
    }
