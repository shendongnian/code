    var sQuery = from x in dataContext.Patients
                 select x;
    if (!string.IsNullOrEmpty(serName.Text))
        sQuery = sQuery.Where(x => x.Name.Contains(serName.Text));
        
    if (!string.IsNullOrEmpty(serSurame.Text))
        sQuery = sQuery.Where(x => x.Surname.Contains(serSurame.Text));
