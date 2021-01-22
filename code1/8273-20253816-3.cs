    public void Foo()
    {
        // High Level Error Handler (Log and Crash App)
        try
        {
            // Init
            List<Action<string>> TestActions = new List<Action<string>>()
                {
                    (key) => { throw new FormatException(); },
                    (key) => { throw new ArgumentException(); },
                    (key) => { throw new KeyNotFoundException();},
                    (key) => { throw new OutOfMemoryException(); },
                };
            // Run
            foreach (var FooAction in TestActions)
            {
                // Mid-Level Error Handler (Log and Break Loop)
                try
                {
                    // Init
                    var SomeKeyPassedToFoo = "FooParam";
                    // Low-Level Handler (Handle/Log and Keep going)
                    try
                    {
                        FooAction(SomeKeyPassedToFoo);
                    }
                    catch (Exception ex)
                    {
                        if (ex.GetType().IsAnyOf(
                            typeof(FormatException),
                            typeof(ArgumentException)))
                        {
                            // Handle
                            Console.WriteLine("ex was {0}", ex.GetType().Name);
                        }
                        else
                        {
                            // Add some Debug info
                            ex.Data.Add("SomeKeyPassedToFoo", SomeKeyPassedToFoo.ToString());
                            throw;
                        }
                    }
                }
                catch (KeyNotFoundException ex)
                {
                    // Handle differently, perhaps for better access to a variable
                    Console.WriteLine(ex.Message);
                    int Count = 0;
                    if (ex != null)
                        foreach (var Key in ex.Data)
                            Console.WriteLine(
                                "[{0}][\"{1}\" = {2}]",
                                Count, Key, ex.Data[Key]);
                }
            }
        }
        catch (OutOfMemoryException)
        {
            Console.WriteLine("FATAL ERROR! System Crashing");
            /*throw; // Crash App*/
        }
    }
