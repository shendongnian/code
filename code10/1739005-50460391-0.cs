     List<string> listOfNationalities = listOfNationalities;
    
    List<string> validNationalities = new List<string>();
    validNationalities.Add("Brazilian");
    validNationalities.Add("Japanese");
    validNationalities.Add("...");
    
    List<string> multiple = listOfNationalities.Where(n => validNationalities.Contains(n));
