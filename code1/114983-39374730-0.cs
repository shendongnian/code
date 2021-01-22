    class MyObject 
    {
          public int id { get; set; }
          public string title { get; set; }
    }
        
    ObservableCollection<MyObject> myCollection = new ObservableCollection<MyObject>();
    
    //add stuff to collection
    // .
    // .
    // .
    myCollection = new ObservableCollection<MyObject>(
        myCollection.OrderBy(n => n.title, Comparer<string>.Create(
        (x, y) => (Utils.Utils.LogicalStringCompare(x, y)))));
