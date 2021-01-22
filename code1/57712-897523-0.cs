    List<string> list = new List<string>();
    
    list.Add("Apple");
    list.Add("Peach");
    list.Add("Chocolate");
    list.Add("Pear");
    list.Add("Pumpkin");
    list.Add("Cherry");
    list.Add("Coconut");
    
    
    var filteredOnes = from item in list
                       where item.StartsWith("P")
                       select item;
