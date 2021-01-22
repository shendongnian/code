    using System.Text.RegularExpressions;
    
    ...
    
    StreamReader reader = FileInfo.OpenText("filename.txt");
    string line;
    while ((line = reader.ReadLine()) != null) {
        Match m = Regex.Match(@"^\d+\t(\d+)\t.+?\t(item\\[^\t]+\.ddj)");
        if (m.Success) {
            int myInt = int.Parse(m.Group(1).Value);
            string path = m.Group(2).Value;
            
            // At this point, `myInteger` and `path` contain the values we want
            // for the current line. We can then store those values or print them,
            // or anything else we like.
        }
    }
