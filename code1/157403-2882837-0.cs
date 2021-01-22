    interface IContactable
    {
       IEnumerable<Contact> Contacts {get;}
    }
    public int CountContacts<TModel>(TModel entity) where TModel : class, IContactable
    {
        return entity.Contacts.Count();
    }
