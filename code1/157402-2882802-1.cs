    public int CountContacts<TModel>(TModel entity) where TModel : IContacts
    interface IContacts
    {
       IList<Contact> Contacts {get;} //list,Ilist,ienumerable
    }
