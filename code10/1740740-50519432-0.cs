    try
    {
        string value = data.Substring(data.IndexOf(index) + index.Length); 
    }
    catch (ArgumentOutOfRangeException e) 
    {
         Console.WriteLine(e.Message);
    }
