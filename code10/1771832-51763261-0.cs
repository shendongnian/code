    try
    {
       int x = int.Parse("a");
       Console.WriteLine(x);
    }
    catch (Exception e)
    {
       Console.WriteLine(e.Message.Reverse().ToArray());
    }
