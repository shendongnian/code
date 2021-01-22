    static void Main(string[] args)
    {
        var Items = GetItems();
    
        foreach (var item in Items) //this will not enter the loop because there are no items in the Items collection
        {
                Console.WriteLine(item);
        }
    
        //if you still need to know if there were items, check the Count() extension method
        if(Items.Count() == 0)
        {
          Console.WriteLine("0 items returned");
        }
    
    
    }
    
    static IEnumerable<string> GetItems()
    {
        if (false)
        {
            yield return "Andy";
            yield return "Jennifer";
        }
    
        yield break;
    }
