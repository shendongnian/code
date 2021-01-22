    class Thing
    {
       public static Thing NewConnection(string connectionString)
       {
           return new Thing(connectionString, true);
       }
    
       public static Thing NewFile(string fileName);
       {
            return new Thing(fileName, false);
       }
    }
    .
    .
    .
    {
        var myObj = Thing.NewConnection("connect=foo");
        var Obj2 = Thing.NewFile("myFile.txt");
    }
