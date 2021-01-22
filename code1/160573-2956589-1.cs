    var allEntries = new SortedList<Entry>();
    string currentLine = null;
    using (var streamReader = new StreamReader("C:\\MyFile.txt"))
        while ((currentLine = streamReader.ReadLine()) != null)
        {
            try
            {
                var entry = new Entry(currentLine);
                allEntries.Add(entry);
            }
            catch (Exception ex)
            {
                //Do whatever you like
                //maybe just
                continue;
                //or
                throw;
            }
        }
