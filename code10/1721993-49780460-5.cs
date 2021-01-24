    using (DataContext dataContext = new DataContext())
    {
        MyClass myClass1 = new MyClass() {Sku = "test1"};
        MyClass myClass2 = new MyClass() {Sku = "test2"};
        MyClass myClass3 = new MyClass() {Sku = "test2"};
        MyClass myClass4 = new MyClass() {Sku = "test3"};
        dataContext.TestTable.Add(myClass1);
        dataContext.TestTable.Add(myClass2);
        dataContext.TestTable.Add(myClass3);
        dataContext.TestTable.Add(myClass4);
        dataContext.SaveChanges();
    }
