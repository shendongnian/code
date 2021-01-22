    using (StreamReader reader = new StreamReader ("/etc/passwd")) {
        string line = "";
        while((line = reader.ReadLine()) != null) {
             string userName = line.Substring(0, line.IndexOf(':'));
        }
    }
