    class MyObject 
    {
        int id;
        string name;
    }
    
    var objectList = new List<MyObject>();
    
    objectList.Add(new MyObject { name = "item 1" });
    objectList.Add(new MyObject { name = string.Empty });
    objectList.Add(new MyObject { name = "item 3" });
    
    var objectsWithName = objectList.Where(x => !string.IsNullOrEmpty(x.name));
    var objectsWithoutName = objectList.Except(objectsWithName);
