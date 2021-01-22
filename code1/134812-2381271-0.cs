    var items = new int?[] { 0, 1, 2, 3, 4, 5, 6 };  // Your array
    var itemList = new List<int?>(items);  // Put the items in a List<>
    itemList.RemoveAt(1); // Remove the item at index 1
    itemList.Add(null); // Add a null to the end of the list
    items = itemList.ToArray(); // Turn the list back into an array
