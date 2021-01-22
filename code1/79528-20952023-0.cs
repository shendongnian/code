    var customers = CustomerRepository.AllEntities();
    
    if (!forename.IsNullOrEmpty())
        customers = customers.Where(p => p.Forename == forename);
    if (!familyname.IsNullOrEmpty())
        customers = customers.Where(p => p.FamilyNames.Any(n => n.Name==familyname));
    if (dob.HasValue)
        customers = customers.Where(p => p.DOB == dob);
