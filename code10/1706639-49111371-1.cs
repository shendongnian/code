    // Some example-class with multiple properties
    public class MyItem
    {
        public string Name { get; set; }
        public double Value { get; set; }
    }
    // Some test-data
    List<MyItem> myList = new List<MyItem>()
    {
        new MyItem() { Name = "One", Value = 1 },
        new MyItem() { Name = "Three", Value = 3 },
        new MyItem() { Name = "Two", Value = 2 }
    }
    
    // select the value you want to use for ordering the list.
    myList = myList.OrderBy(item => item.Value);
    
    // Expected output: 1, 2, 3
    foreach(MyItem item in myList)
    {
        Console.WriteLine(item.Value + ", " + item.Name);
    }
    
    // Expected output: 3, 2, 1
    myList = myList.OrderBy(item => item.Name);
    foreach(MyItem item in myList)
    {
        Console.WriteLine(item.Value + ", " + item.Name);
    }
