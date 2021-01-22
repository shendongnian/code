    UnicodeEncoding uniEncoding = new UnicodeEncoding();
    String message = "Message";
    // You might not want to use the outer using statement that I have
    // I wasn't sure how long you would need the MemoryStream object    
    using(MemoryStream ms = new MemoryStream())
    {
        var sw = new StreamWriter(ms, uniEncoding);
        try
        {
            sw.Write(message);
            sw.Flush();//otherwise you are risking empty stream
            
            // Test and work with the stream here. 
            // If you need to start back at the beginning, be sure to Seek again.
        }
        finally
        {
            sw.Dispose();
        }
    }
