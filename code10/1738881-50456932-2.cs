    try
    {
        //async stuff
    }
    catch (AggregateException ae)
    {
        ae.Handle(x => 
            {
                if (x is FileNotFoundException)
                {
                    Console.WriteLine("I handled the file not found, don't worry");
                    return true;
                }
                return false
            });
    }
