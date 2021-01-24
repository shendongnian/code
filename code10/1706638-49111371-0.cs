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
