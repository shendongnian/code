    string text = "Hello \r\n this is a test \r\n tested";
    string[] lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string line in lines) {
        System.Diagnostics.Debug.WriteLine(line);
    }
