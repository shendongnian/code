    object[] obj = new object[] { };
    DateTime start = DateTime.Now;
    for (int x = 0; x < 1000; x++)
    {
        try
        {
            throw new Exception();
        }
        catch (Exception ex) { }
    }
    DateTime end = DateTime.Now;
    Console.WriteLine("Try/Catch: " + (end - start).TotalSeconds.ToString());
    
    start = DateTime.Now;
    for (int x = 0; x < 1000; x++)
    {
        bool assignable = typeof(int).IsAssignableFrom(obj.GetType().GetElementType());
    }
    end = DateTime.Now;
    Console.WriteLine("IsAssignableFrom: " + (end - start).TotalSeconds.ToString());
