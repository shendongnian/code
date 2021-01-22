    var query = db.Persons;
    if (!string.IsNullOrEmpty(person.CrookBookUserName.Trim()) {
        query = query.Where(p => p.CrookBookUserName.Trim().Contains(person.CrookBookUserName.Trim()));
    }
    if (!string.IsNullOrEmpty(person.email.Trim()) {
        query = query.Where(p => p.email.Trim().Contains(person.email.Trim()));
    }
    // etc...
    return query;
