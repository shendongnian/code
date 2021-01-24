    public class Item
    {
      public int Key {get;set;}
      public string Name {get;set;}
    }
    
    public class Program
    {
      public static void Main()
      {
        List<List<Item>> AllList = new List<List<Item>>();
    
        AllList.Add(new List<Item>() { new Item(){ Key = 503, Name = "A" }, new Item(){ Key = 503, Name = "B" }, new Item(){ Key = 503, Name = "C" }});
        AllList.Add(new List<Item>() { new Item(){ Key = 500, Name = "A" }, new Item(){ Key = 500, Name = "B" }, new Item(){ Key = 500, Name = "C" }});
        AllList.Add(new List<Item>() { new Item(){ Key = 204, Name = "A" }, new Item(){ Key = 204, Name = "B" }, new Item(){ Key = 204, Name = "C" }});
    
        var result = AllList.SelectMany(item => item).OrderBy(item => item.Key).GroupBy(item => item.Key);
    
        foreach(var item in result)
          foreach(var innerItem in item)
            Console.WriteLine(innerItem.Key);
      }
    }
