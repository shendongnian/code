    static void Main(string[] args)
    {
        try
        {   
            // Move this inside teh try block, so catch can catch any exceptions thrown before you get to task1.Wait();
            var task1 = Task.Factory.StartNew(() =>
            {
                throw new Exception("I'm bad, but not too bad!"); // Unhandled Exception here...
            });
            task1.Wait(); // Exception is not handled here....
        }
        catch (AggregateException ae)
        {
            foreach (var e in ae.InnerExceptions)
            {
                Console.WriteLine(e.Message);
            }
        }
        Console.ReadLine();
    }
