    String title = webDriver.Title;
    String expectedTitle = "Utilities from Go Compare";
    if (title.Contains(expectedTitle))
    {
        Console.WriteLine("Title is matching with expected value");
    }
    else
    {
        throw new Exception("Title does not match");
    }
