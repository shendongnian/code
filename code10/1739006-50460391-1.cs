     string listOfNationalities = string.Join("|",listOfNationalities);
    
    List<string> validNationalities = new List<string>();
    validNationalities.Add("Brazilian");
    validNationalities.Add("Japanese");
    validNationalities.Add("...");
    
    List<string> multiple = validNationalities.Where(n => listOfNationalities.Contains(n));
