    DataTable Search(
        string firstName,
        string middleName,
        string lastName,
        string ssn,
        DateTime? birthdate
    ) {
    IQueryable<Person> query = context.tblPersons;
    if(SearchParameterIsValid(firstName)) {
        query = SearchByFirstName(query, firstName);
    }
    if(SearchParameterIsValid(middleName)) {
        query = SearchByMiddleName(query, middleName);
    }
    if(SearchParameterIsValid(lastName)) {
        query = SearchByLastName(query, lastName);
    }
    if(SearchParameterIsValid(ssn)) {
        query = SearchBySSN(query, ssn);
    }
    if(birthDate != null) {
        query = SearchByBirthDate(query, birthDate);
    }
    // fill up and return DataTable from query
}
    bool SearchParameterIsValid(string s) {
        return !String.IsNullOrEmpty(s);
    }
    IQueryable<Person> SearchByFirstName(
        IQueryable<Person> source,
        string firstName
    ) {
       // something like
       return from p in source
              where p.FirstName == firstName || p.FirstName.StartsWith(firstName)
              select p;
    }
    
