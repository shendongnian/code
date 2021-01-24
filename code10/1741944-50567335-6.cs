    string[] tests = new string[] {
      "Personnel.FirstName1",  // the only string that should be matched
      "2Personnel.FirstName1",
      "Personnel.33FirstName",
      "Personnel..FirstName",
      "Personnel.;FirstName",
      "Personnel.FirstName.",
      "Personnel.FirstName   ",
      " Personnel.FirstName",
      " Personnel. FirstName",
      " 23Personnel.3FirstName",
    } ;
    string pattern = @"^[A-Za-z_][A-Za-z0-9_]*(\.[A-Za-z_][A-Za-z0-9_]*)*$";
    var results = tests
      .Select(test => 
        $"{"\"" + test + "\"",-25} : {(Regex.IsMatch(test, pattern) ? "matched" : "failed")}"");
    Console.WriteLine(String.Join(Environment.NewLine, results));
