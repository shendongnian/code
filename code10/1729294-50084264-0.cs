    List<Item> yourList = new List<Item>(); //Create an empty list
    /* Or
     * List<Item> youtList = new List<Item>()
     * {
     *     new Item(),
     *     new Item() //etc
     * }
     */
    yourList.Add(new Item()); //Add an item 
    yourList.Insert(0, new Item()); //Insert an item to the 0 index
    yourList.Remove(yourItem); //Remove an item directly
    yourList.RemoveAt(0); //Remove an item by its index in the list
    Item[] yourArray = yourList.ToArray(); //Convert the list List<T> to an array T[]
