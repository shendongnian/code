    using System.Text.RegularExpressions;
    
    ...
    
    Regex parts = new Regex(@"^\d+\t(\d+)\t.+?\t(item\\[^\t]+\.ddj)");
    StreamReader reader = FileInfo.OpenText("filename.txt");
    string line;
    while ((line = reader.ReadLine()) != null) {
        Match match = parts.Match(line);
        if (match.Success) {
            int number = int.Parse(match.Group(1).Value);
            string path = match.Group(2).Value;
            
            // At this point, `number` and `path` contain the values we want
            // for the current line. We can then store those values or print them,
            // or anything else we like.
        }
    }
