    //var list = new List<int> { 1, 2, 3, 4, 5, 6 }; // Your sample collection
    
    var listEnumerator = list.GetEnumerator(); // Get enumerator
    for (var i = 0; listEnumerator.MoveNext() == true; i++)
    {
      int currentItem = listEnumerator.Current; // Get current item.
      //Console.WriteLine("At index {0}, item is {1}", i, currentItem); // Do as you wish with i and  currentItem
    }
