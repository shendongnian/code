    List<MyClass> list = new List<MyClass>();
    list.Add(new MyClass("Peter", 1202));
    list.Add(new MyClass("James", 292));
    list.Add(new MyClass("Bond", 23));
    
    // Added sortable list...
    SortableBindingList<MyClass> sortableList = new SortableBindingList<MyClass>(list);
    
    BindingSource bs = new BindingSource();
    bs.DataSource = sortableList;   // Bind to the sortable list
