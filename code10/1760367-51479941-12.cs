    private static async Task<T> ExcecuteWithLogging<T>(Func<T> function)
    {
        try
        {
            
            var result =  function();
            if (result is Task<T> t)
            {
                return await t;
            }
            return result;
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Console.WriteLine(message);
        }
        Console.WriteLine("Returning..");
        return default(T);
    }
