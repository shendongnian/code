    string xml = File.ReadAllText(@"C:\testing_doc.txt");
    string pattern = "<test>(.*?)</test>";
    Match match = Regex.Match(xml , pattern);
    if (match.Success){
        System.Console.WriteLine(match.Groups[1].Value);
    }
