    public class itemsList
    {
         public string itemName;
         public int itemCount;
    }
    
    ...
    private readonly Dictionary<string, itemsList> ItemsDict = new Dictionary<string, itemsList>();
    // here we add an object
    ItemsDict.Add(someItemName, myItem);
