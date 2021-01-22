    private static bool Handle(Exception e)
    {
        Console.WriteLine("Handle the exception here :-)");
        return true; // false will re-throw;
    }
    public static void Main()
    {
        try
        {
            throw new OutOfMemoryException();
        }
        catch (ArgumentException e)
        {
            if (!Handle(e)) { throw; }
        }
        catch (IndexOutOfRangeException e)
        {
            if (!Handle(e)) { throw; }
        }
        Console.WriteLine("We're done with the exception handling.");
