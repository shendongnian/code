    string line = string.Empty;
    List<string> lines = new List<string>();
    string path = @"c:\Name.txt";
    if (File.Exists(path)) {
        System.IO.StreamReader file = new System.IO.StreamReader(path);
        while ((line = file.ReadLine()) != null) {
            if (line == "David") { // Give your search term here!
                lines.Add("\"find my word\"");
            }
            lines.Add(line);
        }
        file.Close();
    }    
    File.WriteAllLines(path, lines);
