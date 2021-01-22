     public class Items
        {
            public string Name { get; set; }
            public List<Items> SubCategories { get; set; }
            public string IsLeaf { get; set; }
            public string Parent { get; set; }
        }  
