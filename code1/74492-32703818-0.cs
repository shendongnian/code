    try
    {
        reader1 = new StreamReader(path1);
        // if we got this far, path 1 succeded, so try path2
        try
        {
            reader2 = new StreamReader(path2);
    
        }
        catch (OIException ex)
        {
            // Uh oh something went wrong with opening the file2 for reading
            // Nevertheless, have a look at file1. Its fine!
        }
    }
    catch (OIException ex)
    {
        // Uh oh something went wrong with opening the file1 for reading.
        // So I didn't even try to open file2
    }
