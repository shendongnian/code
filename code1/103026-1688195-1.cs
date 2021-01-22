     public class Item
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int ID { get; set; }
            public int Priority { get; set; }
            public bool Included { get; set; }
            public IList<string> Data { get; set; }
        }
