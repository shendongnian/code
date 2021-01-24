        public class Item
        {
            public int ItemId { get; set; }
            public virtual ICollection<Property> Properties { get; set; }
        }
        public class Property
        {
            public int PropertyId { get; set; }
            public int ItemId { get; set; }
            public string Name { get; set; }
            public int? DisplayMode { get; set; }
            public int? Type { get; set; }
            public int? Progress { get; set; }
            public Item Item { get; set; }
            public virtual ICollection<PropertyValue> Values { get; set; }
        }
