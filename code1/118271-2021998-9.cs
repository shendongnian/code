    DataTable Search(
        string firstName,
        string middleName,
        string lastName,
        string ssn,
        DateTime? birthdate
    ) {
        Predicate<Person> predicate = p => true;
        if(SearchParameterIsValid(firstName)) {
            predicate = PredicateAnd(predicate, FirstNamePredicate(firstName));
        }
        if(SearchParameterIsValid(middleName)) {
            predicate = PredicateAnd(predicate, MiddleNamePredicate(middleName));
        }
        // etc.
    }
   
    Predicate<T> PredicateAnd<T>(Predicate<T> first, Predicate<T> second) {
        return t => first(t) && second(t);
    }
    Predicate<Person> FirstNamePredicate(string firstName) {
        return p => p.FirstName == firstName || p.FirstName.StartsWith(firstName);
    }
    // etc.
    DataTable SearchByPredicate(
        IQueryable<Person> source,
        Predicate<Person> predicate
    ) {
        var query = source.Where(predicate)
                          .Join(
                              context.tblAddresses,
                                  p => p.PersonID,
                                  a => a.PersonID,
                                  (p, a) => new {
                                      p.PersonID,
                                      p.LastName,
                                      p.FirstName,
                                      p.SSN,
                                      a.AddressLine1
                                  }
                              );
        return query.CopyLinqToDataTable();
    }
