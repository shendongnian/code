    var pattern = @"*root*";
    Regex rgx = new Regex(pattern);
    using (StreamReader r = new StreamReader("filename.json"))
    {
     string json1 = r.ReadToEnd();
     if (rgx.IsMatch(json1))
     {
        filename = path + @"" + branch + "-" + testsuite.Title + ".json";
     }
    }
