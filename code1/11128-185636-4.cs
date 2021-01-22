    Writer writer = null;
    try
    {
        writer = new Writer();
        writer.Write("Hello");
    }
    finally
    {
        if( writer != null)
        {
            ((IDisposable)writer).Dispose();
        }
    }
