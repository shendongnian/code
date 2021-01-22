    private void WriteItem<T>(StreamWriter sr, T item)
    {
        string itemString = item.ToString();
        if(itemString.IndexOfAny('"', ',', '\n', '\r') != -1)//skip test and always escape for different speed/filesize optimisation
        {
            sr.Write('"');
            sr.Write(itemString.Replace("\"", "\"\""));
            sr.Write('"');
        }
        else
            sr.Write(itemString);
    }
    private void WriteLine<T>(StreamWriter sr, IEnumerable<T> line)
    {
        bool first = true;
        foreach(T item in line)
        {
            if(!first)
                sr.Write(',');
            first = false;
            WriteItem(sr, item);
        }
    }
    private void WriteCSV<T>(StreamWriter sr, IEnumerable<IEnumerable<T>> allLines)
    {
        bool first = true;
        foreach(IEnumerable<T> line in allLines)
        {
            if(!first)
                sr.Write('\n');
            first = false;
            WriteLine(sr, line);
        }
    }
    private void WriteCSV<T>(HttpResponse response, IEnumerable<IEnumerable<T>> allLines)
    {
        response.ContentType = "text/csv";
        WriteCSV(response.Output, allLines);
    }
