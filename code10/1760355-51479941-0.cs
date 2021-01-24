    public static async void SearchByPersonnummerAsync(string personnummer)
    {
        var aaa = await ExcecuteWithLogging(async () =>
        {
            Console.WriteLine("Executing function");
            var res = await Task.Run(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine("Before crashing");
                throw new Exception();
                return 1;
            });
            Console.WriteLine("Finishing execution");
            return res;
        });
    }
    private static T ExcecuteWithLogging<T>(Func<T> function)
    {
        try
        {
            Console.WriteLine("Before calling function");
            function();
            Console.WriteLine("After calling function");
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            Console.WriteLine(message);
        }
        Console.WriteLine("Returning..");
        return default(T);
    }
