    var contact = (from cont in db.Contacts
        from note in db.Contacts_Notes.Where(n => n.ContactID == cont.ContactID).DefaultIfEmpty()
        where cont.AccountID == this.AccountID && cont.ContactID == this.ContactID
        select this.RenewSelf(
            cont.AccountID,
            cont.CompanyName,
            cont.ContactID,
            cont.Firstname,
            cont.JobTitle,
            cont.Lastname,
            note.Note
        ).SingleOrDefault();
