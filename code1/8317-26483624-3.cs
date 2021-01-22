    Exception ex = null;
    try
    {
        throw new ArgumentException();
    }
    catch (ArgumentOutOfRangeException e)
    {
        ex = e;
    }
    catch (IndexOutOfRangeException e)
    {
        ex = e;
    }
    if (ex != null)
    {
        Console.WriteLine("Handle the exception here :-)");
    }
