            List<ContactWithPrimary> Contacts = DataContext.Contacts
                .Select(con => new ContactWithPrimary 
                { 
                    Contact = con, 
                    PrimaryEmail = con.PrimaryEmail, 
                    PrimaryAddress = con.PrimaryAddress 
                }).ToList();
