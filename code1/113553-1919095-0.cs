    var ResultsFromProfiles = from AllPeeps in SearchDC.aspnet_Users select AllPeeps;
    
    IEnumerable<AspNet_User> total = new AspNew_User[0];
    
    if (SearchFirstNameBox.Checked)
    {    
        total = total.Concat(ResultsFromProfiles.Where(p => p.tblUserProfile.FirstName.Contains(SearchTerm));}
    }
    
    if (SearchLastNameBox.Checked)
    {
       total = total.Concat(ResultsFromProfiles.Where(p => p.tblUserProfile.LastName.Contains(SearchTerm));
    }
    
    total = total.Distinct();
