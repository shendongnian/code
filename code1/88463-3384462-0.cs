    ContactRepository.cs
    
    public IQueryable<Contact> GetContacts()
    {
        return (from q in SqlContext.Contacts
                select q).AsQueryable();
    }
