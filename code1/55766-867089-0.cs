    int total;
    
    DateTime startTime = DateTime.Now;
    
    for(int i = 0; i < 20000; i++)
    {
    try
    {
    total += i;
    }
    catch
    {
    // nothing to catch;
    }
    }
    
    Console.Write((DateTime.Now - startTime).ToString());
