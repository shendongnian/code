            JArray json = JArray.Parse(
                (new StreamReader(General.GetEmbeddedFile("Contacts.json")).ReadToEnd()));
            IList<Contact> tempContacts = (from c in json
                                           select new Contact
                                           {
                                               ID = (int)c["ID"],
                                               Name = (string)c["Name"],
                                               Details = new LazyList<ContactDetail>(
                                                   (
                                                       from cd in c["Details"]
                                                       select new ContactDetail
                                                       {
                                                           ID = (int)cd["ID"],
                                                           OrderIndex = (int)cd["OrderIndex"],
                                                           Name = (string)cd["Name"],
                                                           Value = (string)cd["Value"]
                                                       }
                                                    ).AsQueryable()),
                                               Updated = (DateTime)c["Updated"]
                                           }).ToList<Contact>();
            return tempContacts;
