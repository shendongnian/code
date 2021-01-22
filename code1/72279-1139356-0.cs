    static void Main(string[] args)
    {
        StreamWriter writer = new StreamWriter(@"c:\path\file.ext");
        try
        {
            Console.SetOut(writer);
            Console.WriteLine("One");
            Console.WriteLine("Two");
            Console.WriteLine("Three");
        }
        catch (Exception ex)
        {
            Console.WriteLine("That went wrong.");
        }
        finally
        {
            writer.Dispose();
        }    
    }
