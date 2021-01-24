    private static async Task<T> ExcecuteWithLogging<T>(Func<Task<T>> function)
    {
        T result;
        try
        {
            Console.WriteLine("Before calling function");
            result =  await function();
            Console.WriteLine("After calling function");
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Console.WriteLine(message);
            return default(T);
        }
        Console.WriteLine("Returning..");
        return result;
    }
