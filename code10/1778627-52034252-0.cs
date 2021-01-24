    public class CounterIterator : List<Item>
    {
        public new void Add(Item item)
        {
            base.Add(item);
            foreach (var listItem in this)
            {
                if (listItem.Equals(item))
                {
                    item.CountRepeat++;
                }
            }
        }
    }
    public class Item
    {
        public Item(string value)
        {
            Value = value;
        }
        public string Value { get; private set; }
        public int CountRepeat { get; set; }
        public override bool Equals(object obj)
        {
            var item = obj as Item;
            return item != null && Value.Equals(item.Value);
        }
    }
