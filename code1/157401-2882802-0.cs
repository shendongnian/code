    public int CountContacts<TModel>(TModel entity) where TModel : IContacts
    interface IContacts
    {
       List<Contact> Contacts {get;}
    }
