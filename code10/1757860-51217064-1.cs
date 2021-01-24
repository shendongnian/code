    public class Item
    {
        public string id { get; set; }
        public string descricao { get; set; }
        public string observacao { get; set; }
        public string status { get; set; }
    }
    
    public class Data
    {
        public List<Item> item { get; set; }
        public int count { get; set; }
    }
    
    public class Category
    {
        public string code { get; set; }
        public bool result { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
