    Writer writer = new Writer();
    try
    {        
        writer.Write("Hello");
    }
    finally
    {
        if( writer != null)
        {
            ((IDisposable)writer).Dispose();
        }
    }
