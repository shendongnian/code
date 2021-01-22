    try
    {
        assembly = Assembly.GetExecutingAssembly();
        Log.Write("Executing assembly is null: " + (assembly == null))
    }
    catch(Exception ex)
    {
        //Write exception to server event log
    }
