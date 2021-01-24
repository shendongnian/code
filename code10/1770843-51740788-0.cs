    static void Main(string[] args)
    {
        try
        {
            var preformTask = Task.Run( () => Preform() );
            DoSomethingElse();    // if needed
            preformTask.Wait();   // wait for preformTask to finish
            Console.WriteLine("Task completed; press any key to finish");
            Console.ReadKey();
        }
        catch (Exception exc) // inclusive ggregateException if one of your Task fails
        {
            ProcessException(exc)
        }
    }
    static async Task preform()
    {
        // To be certain that the Console Line has been written: await
        await Takingtime();
        // if here, you are certain that the Line has been written,
        // or course you have lost parallel processing
        await Working();
    }
