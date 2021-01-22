    public static Load(int contactID, int accountID) //If they are integers
    {
        return (from cont in db.Contacts
            from note in db.Contacts_Notes.Where(n => n.ContactID == cont.ContactID).DefaultIfEmpty()
            where cont.AccountID == accountID && cont.ContactID == contactID
            select new Contact
            {
                //... stuff
            }).SingleOrDefault();
    }
