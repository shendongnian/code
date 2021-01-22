    StreamWriter writer;
    try
    {
        writer = new StreamWriter(Response.OutputStream);
        writer.WriteLine("col1,col2,col3");
        writer.WriteLine("1,2,3");
    }
    catch
    {
        throw;
    }
    finally
    {
        if (writer != null)
        {
            writer.Close();    
        }
    }
