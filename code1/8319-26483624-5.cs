    try
    {
        throw new ArgumentException();
    }
    catch (Exception e)
    {
        Exception ex = (Exception)(e as ArgumentException) ?? (e as IndexOutOfRangeException);
        if (ex != null)
        {
            Console.WriteLine("Handle the exception here :-)");
            // throw ?
        }
        else 
        {
            throw;
        }
    }
