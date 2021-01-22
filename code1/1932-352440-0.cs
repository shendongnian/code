    using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
    {
        StringBuilder sb = new StringBuilder();
    
        try
        {
            while (!sr.EndOfStream)
            {
                sb.Append((char)sr.Read());
            }
        }
        catch (System.IO.IOException)
        { }
    
        string content = sb.ToString();
    }
