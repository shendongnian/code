    String pipedText = "";
    bool isKeyAvailable;
    
    try
    {
        isKeyAvailable = System.Console.KeyAvailable;
    }
    catch (InvalidOperationException nil)
    {
        pipedText = System.Console.In.ReadToEnd();
    }
    
    //do something with your pipedText
