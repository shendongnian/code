    static void Main(string[] args)
    {
        string answer = Sample();
        Console.WriteLine(answer);
    }
    
    public static string Sample()
    {
        string returnValue;
        try
        {
            returnValue = "abc";
        }
    
        catch (Exception)
        {
            throw;
        }
    
        finally
        {
            returnValue = "def";
        }
        return returnValue;
    }
