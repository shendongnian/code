    string serachKeyword ="o";
                
    List<string> states = new List<string>();
    states.Add("Frederick");
    states.Add("Germantown");
    states.Add("Arlington");
    states.Add("Burbank");
    states.Add("Newton");
    states.Add("Watertown");
    states.Add("Pasadena");
    states.Add("Maryland");
    states.Add("Virginia");
    states.Add("California");
    states.Add("Nevada");
    states.Add("Ohio");
    
    List<string> searchResults = states.FindAll(s => s.Contains(serachKeyword));
