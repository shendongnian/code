    // Load the file contents
    string contents = File.ReadAllText("example.txt");
    
    // Obtain the data using regular expressions
    string id = string id = Regex.Match(contents, @"CoreDBCaseID=(?<id>\d+)").Groups["id"].Value;;
    string server = string.Empty; // Add regex here
    string security = string.Empty; // Add regex here
    string database = string.Empty; // Add regex here
    
    // Save the data in the new format
    string[] data = new string[] {
        String.Format("Table={0}", id),
        String.Format("Server={0}", server),
        String.Format("Security={0}", security),
        String.Format("Database={0}", database)
    };
    
    File.WriteAllLines("output.txt", data);
