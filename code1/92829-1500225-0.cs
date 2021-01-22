    using (StringReader reader = new StringReader(input))
    {
        string line = string.Empty;
        do
        {
            line = reader.ReadLine();
            if (line != null)
            {
                // do something with the line
            }
    
        } while (line != null);
    }
