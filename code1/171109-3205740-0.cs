    private Func<string, Expression<Func<Contact, bool>>> FilterDefinition =
        val => c => c.CompanyName.Contains(val);
    private IQueryable<Contact> ApplyFilter(
        IQueryable<Contact> contacts, string filterValue)
    {
        return contacts.Where(FilterDefinition(filterValue));
    }
