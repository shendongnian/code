    using (TextReader reader = new TextReader(someStream)) {
        string line = "";
        while((line = reader.ReadLine()) != null) {
             string userName = line.Substring(0, line.IndexOf(':'));
        }
    }
