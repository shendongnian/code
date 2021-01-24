    try
    {
        var validJson = JsonValue.Parse(strData);
    }
    catch (FormatException e)
    {
        //Invalid Json Format
        Console.WriteLine(e);
    } 
    catch (Exception e)
    {
        //some other exception
    }
