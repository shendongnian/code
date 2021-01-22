    using (StreamReader f1 = new StreamReader(path1))
    using (StreamReader f2 = new StreamReader(path2)) {
        var differences = new List<string>();
        int lineNumber = 0;
        while (!f1.EndOfStream) {
            if (f2.EndOfStream) {
               differences.Add("Differing number of lines - f2 has less.");
               break;
            }
        
            lineNumber++;
            var line1 = f1.ReadLine();
            var line2 = f2.ReadLine();
            if (line1 != line2) {
               differences.Add(string.Format("Line {0} differs. File 1: {1}, File 2: {2}", lineNumber, line1, line2);
            }
        }
        if (!f2.EndOfStream) {
             differences.Add("Differing number of lines - f1 has less.");
        }
    }
