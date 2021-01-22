    public IPerson GetPerson(Person p) //I'm guessing that the objects in collection db.Persons is of type Person
    {
        IPerson ret;
        switch(p.TypeId)
        {
            case (int)PersonType.Student: ret = .......break;
            case (int)PersonType.Employee: ret = ......break;
        }
        return ret;
    }
    
    public IQueryable<IPerson> getPersons() {
        return (from p in db.Persons select p).ToList().Select(p => GetPerson(p)).AsQueryable();
    }
