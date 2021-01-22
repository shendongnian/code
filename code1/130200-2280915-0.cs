    //your data container class 
     public class MyClass
        {
            public string Name { get; set; }
        }
    
    //Put all classes into the list before caching it 
    List<MyClass> source = new List<MyClass>() ; 
    
    //use this to sort with any kind of data inside your own defined class 
    var sortedResult = source.OrderBy(x => x.Name);
