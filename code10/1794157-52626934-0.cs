    var lines = new List<string>();
    using(StreamReader reader = new StreamReader(file.InputStream))
    {
        do
        {
            string textLine = reader.ReadLine();
            lines.Add(textLine);  
        } while (reader.Peek() != -1);
    }
