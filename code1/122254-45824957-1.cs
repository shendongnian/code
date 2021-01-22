    public class Item
    {
      public string Key { get; }
      public string Value { get; set; }
      public Item(string key, string value = null) { Key = key; Value = value; }
    }
    public class Lookup : Lookup<string, Item>
    {
      protected override string GetKeyForItem(Item item) => item.Key;
    }
    static void Main(string[] args)
    {
      var toRem = new Item("1", "different");
      var single = new Item("2", "single");
      var lookup = new Lookup()
      {
        new Item("1", "hello"),
        new Item("1", "hello2"),
        new Item(""),
        new Item("", "helloo"),
        toRem,
        single
      };
      lookup.Remove(toRem);
      lookup.Remove(single);
    }
