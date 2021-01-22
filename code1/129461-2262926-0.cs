    PeopleDataContext people = new PeopleDataContext();     
    Person p = people.People.Single(person => person.ID == 1);     
    p.IDRole = 2;
     
    try
    { people.SubmitChanges(ConflictMode.ContinueOnConflict); }
    catch (ChangeConflictException cce)
    { people.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges); }
