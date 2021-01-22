    // let this be your real list of objects    
    List<MyClass> myClasses = new List<MyClass>() 
    {
        new MyClass () { MonthYear = new DateTime (2010,1,1), Quantity = 3},
        new MyClass() { MonthYear = new DateTime (2010,12,1), Quantity = 2}
    };
    
    List<MyClass> fillerClasses = new List<MyClass>();
    for (int i = 1; i < 12; i++)
    {
        MyClass filler = new MyClass() { Quantity = 0, MonthYear = new DateTime(2010, i, 1) };
        fillerClasses.Add(filler);
    }
    
    myClasses.AddRange(fillerClasses.Except(myClasses, new MyClassEqualityComparer()));
