    public static List<Person> GetResult(SearchParam search, List<Person> persons)
    {
        if (search == null || persons == null)
        {
            return persons;
        }
        var ignoreCase = StringComparison.CurrentCultureIgnoreCase;
        var firstNamePrefix = string.IsNullOrWhiteSpace(search.FirstName) ? "" : search.FirstName;
        var lastNamePrefix = string.IsNullOrWhiteSpace(search.LastName) ? "" : search.LastName;
        return persons.Where(p => p.FirstName.StartsWith(firstNamePrefix, ignoreCase))
                      .Where(p => p.LastName.StartsWith(lastNamePrefix, ignoreCase))
                      .Where(p => p.DOB.Equals(search.DOB ?? p.DOB))
                      .ToList();
    }
