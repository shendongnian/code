    public IEnumerable<LogEntry> GetAllValidEntries() {
        while (!logReader.Finished) {
            string nextLine = logReader.ReadLine();
            LogEntry nextEntry;
            
            if (TryParseLogEntry(nextLine, out nextEntry))
                yield return nextEntry;
        }
    }
    private bool TryParseLogEntry(string line, out LogEntry logEntry) {
        logEntry = null;
        
        if (string.IsNullOrEmpty(line))
            return false;
        
        string[] cells = line.Split(';');
        if (cells.Length < 3)
            return false;
        
        DateTime time;
        decimal price;
        int quantity;
        
        // We just want to read this line of text as a LogEntry
        // IF it is valid; otherwise, there's no reason to throw
        // an error in the user's face
        if (!DateTime.TryParse(cells[0], out time) ||
            !decimal.TryParse(cells[1], out price) ||
            !int.TryParse(cells[2], out quantity))
            return false;
        
        logEntry = new LogEntry(time, price, quantity);
        return true;
    }
