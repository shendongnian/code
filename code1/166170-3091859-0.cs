    static public void Main()
    {
        try
        {
            TypeInit t = TypeInit.Instance;
        }
        catch (TypeInitializationException tiex)
        {
            var ex = tiex.InnerException;
            Console.WriteLine("Exception from type init: '{0}'", ex.Message);
        }
    }
