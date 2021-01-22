    static void Main(string[] args)
    {
        string answer;
        Sample(out answer);
        Console.WriteLine(answer);
    }
    
    public static void Sample(out string answer)
    {
    
        try
        {
            answer = "abc";
            return;
        }
    
        catch (Exception)
        {
            throw;
        }
    
        finally
        {
            answer = "def";
        }
    }
