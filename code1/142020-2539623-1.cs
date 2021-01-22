    var f = new Foo();
    f.Bar = new ObservableCollection<int>();
    f.Bar.AddRange(new int[] { 1, 2, 3, 4 });
    // ...
    // Attaches and handlers to the collection events
    // ...
    f.Bar = new ObservableCollection<int>();
    f.Bar.AddRange(new int[] { 5, 6, 7, 8 });
    
