    public Contact CreateContact(Contact contact)
    {
        _entities.AddToContact(contact); //no longer throws the exception
        _entities.SaveChanges();
        return contact ;
    }
