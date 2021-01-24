        public class MyClass
    {
        public int myProperty {get;set;}
        .
        .
        .
        .
        .
    }
    
    List<MyClass> tList = 
        new List<MyClass>();
    foreach (var item in itemList)
    {
        newCol = new MyClass(....);
        tList.Add(newCol);
    }
