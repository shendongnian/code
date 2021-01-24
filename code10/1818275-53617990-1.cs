    StreamWriter writer = new StreamWriter(file);
    try
    {
        // do something with writer
    }
    finally
    {
        if(writer != null)
            writer.Dispose(); // close handle and free resorces
    }
