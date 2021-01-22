    String pipedText = "";
    bool isKeyAvailable;
    
    try
    {
        isKeyAvailable = System.Console.KeyAvailable;
    }
    catch (InvalidOperationException expected)
    {
        pipedText = System.Console.In.ReadToEnd();
    }
    
    //do something with your pipedText
