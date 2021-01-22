    string[] tests = {
       "AutomaticTrackingSystem",
       "XMLEditor",
    };
     
    Regex r = new Regex(@"(?!^)(?=[A-Z])");
    foreach (string test in tests) {
       Console.WriteLine(r.Replace(test, " "));
    }
