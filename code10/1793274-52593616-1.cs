    // Set "x" to be whatever you want based on your requirements --
    // this is the number of items that will precede the "priority" items in the
    // sorted list
    var x = 3;
    var sortedList = list
       .Select((item, index) => Tuple.Create(item, index))
       .OrderBy(item => {
           // If the original position of the item is below whatever you've 
           // defined "x" to be, then keep the original position
           if (item.Item2 < x) {
              return item.Item2;
           } 
       
           // Otherwise, ensure that "priority" items appear first
           return item.Item1.flag == 1 ? x + item.Item2 : list.Count + x + item.Item2;
    }).Select(item => item.Item1);
