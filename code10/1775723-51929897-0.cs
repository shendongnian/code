    try 
    {
        onReceive.Invoke(packet);
    }
    catch(Exception e)
    {
        Debug.WriteLine(e.Message);
    }
