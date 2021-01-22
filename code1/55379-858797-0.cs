    StreamReader reader = FileInfo.OpenText("filename.txt");
    string line;
    while ((line = reader.ReadLine()) != null) {
        string items[] = line.Split('\t');
        int myInteger = int.Parse(items[1]); // Here's your integer.
        // Now let's find the path.
        string path = null;
        foreach (string item in items) {
            if (item.StartsWith("item\\") && item.EndsWith(".ddj")) {
                path = item;
            }
        }
        
        // At this point, `myInteger` and `path` contain the values we want
        // for the current line. We can then store those values or print them,
        // or anything else we like.
    }
