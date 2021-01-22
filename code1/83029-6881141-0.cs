    from s in Session.Linq<Client> left join cc in c.Contacts
            on
            new { c.ClientID , cc.ClientID }
            equals
             new { cc.ContactType, "Email" }
            select c.ClientId;
