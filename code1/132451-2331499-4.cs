    void MyMethod(object someObject)
    {
       someObject = null;
    }
    
    object someObject = new object();
    MyMethod(someObject);
    Console.WriteLine(someObject == null); // Prints false
