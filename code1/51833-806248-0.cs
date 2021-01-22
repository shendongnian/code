    FileStream fs = null;
    
    try
    {
      fs = new FileStream(...)
    
      // process the data
    
    }
    catch (IOException)
    {
      // inside this catch block is where you put code that recovers
      // from an IOException
    }
    finally
    {
      // make sure the file gets closed
      if (fs != null) fs.Close();
    }
