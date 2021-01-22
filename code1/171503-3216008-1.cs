    String password  = @"\/\/4573Fu|_";
    Dictionary<string, string> leetRules = new Dictionary<string, string>();
    
    leetRules.Add("4", "A");
    leetRules.Add(@"/\", "A");
    leetRules.Add("@", "A");
    leetRules.Add("^", "A");
    
    leetRules.Add("13", "B");
    leetRules.Add("/3", "B");
    leetRules.Add("|3", "B");
    leetRules.Add("8", "B");
    leetRules.Add("><", "X");
    leetRules.Add("<", "C");
    leetRules.Add("(", "C");
    leetRules.Add("|)", "D");
    leetRules.Add("|>", "D");
    leetRules.Add("3", "E");
    leetRules.Add("6", "G");
    leetRules.Add("/-/", "H");
    leetRules.Add("[-]", "H");
    leetRules.Add("]-[", "H");
    leetRules.Add("!", "I");
    leetRules.Add("|_", "L");
    leetRules.Add("_/", "J");
    leetRules.Add("_|", "J");
    leetRules.Add("1", "L");
    leetRules.Add("0", "O");
    leetRules.Add("5", "S");
    leetRules.Add("7", "T");
    leetRules.Add(@"\/\/", "W");
    leetRules.Add(@"\/", "V");
    leetRules.Add("2", "Z");
    foreach (KeyValuePair<string,string> x in leetRules)
    {
        password = password.Replace(x.Key, x.Value);
    }
    MessageBox.Show(password.ToUpper());
