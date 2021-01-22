    UnicodeEncoding uniEncoding = new UnicodeEncoding();
    String message = "Message";
    // You might not want to use the outer using statement that I have
    // I wasn't sure how long you would need the MemoryStream object    
    using(MemoryStream ms = new MemoryStream())
    {
        using(StreamWriter sw = new StreamWriter(ms, uniEncoding))
        {
            sw.Write(message);
        }
    
        ms.Seek(0, SeekOrigin.Begin);
    
        // Test and work with the stream here. 
        // If you need to start back at the beginning, be sure to Seek again.
    }
