    public static void Write(object msg) 
    {
        WriteTimeStamp();
        dynamic dynMsg = msg;
        Console.WriteLine(dynMsg); 
    }
