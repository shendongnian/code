    // class definition
    public class Item
    {
        public long Id { get; set; }
        public string Value { get; set; }
    }
    
    // create your list
    var items = new List<Item>
    {
        new Item{Id = 0, Value = "value0a"},
        new Item{Id = 0, Value = "value0b"},
        new Item{Id = 1, Value = "value1"}
    };
    
    // this approach results in a List<string> (a collection of the values)
    var lookup = items.ToLookup(i => i.Id, i => i.Value);
    var groupOfValues = lookup[0].ToList();
    
    // this approach results in a List<Item> (a collection of the objects)
    var itemsGroupedById = items.GroupBy(i => i.Id).ToList();
    var groupOfItems = itemsGroupedById[0].ToList();
