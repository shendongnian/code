    UnicodeEncoding uniEncoding = new UnicodeEncoding();
    String message = "Message";
    
    using(MemoryStream ms = new MemoryStream())
    {
        using(StreamWriter sw = new StreamWriter(ms, uniEncoding))
        {
            sw.Write(sw);
        }
    
        ms.Seek(0, SeekOrigin.Begin);
    
        // Test and work with the stream here. 
        // If you need to start back at the beginning, be sure to Seek again.
    }
