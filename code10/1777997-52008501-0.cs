    try
    {
        using(var con = DataService.GetSomethingDisposable()) // Possible InvalidOperationException();
        {
            // Do what you need here
            // Possible Exception here
        }
    }
    catch(InvalidOperationException ex)
    {
        // Handle as you will
    }
    catch(Exception ex) // Catch any other exception
    {
        // Handle as you will
    }
