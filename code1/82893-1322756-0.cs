    var storedData = new[]{
        new int[] {1, 2, 3, 4},
        new int[] {1, 2, 3, 4, 5}
    };
    var itemsFromTextBox = new[] { 3, 4, 5 };
    
    var query = storedData.Where(a => a.ContainsAny(itemsFromTextBox))
        .OrderByDescending(a => itemsFromTextBox.Sum(i => a.Contains(i)? 1:0));
