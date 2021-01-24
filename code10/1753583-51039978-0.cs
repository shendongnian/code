    var medProvidersInput = db.Contacts.Where(s => s.Id == id && s.ContactCategory.Name == "Facility").Select(a => new
                {
                    Id = a.Id,
                    Firstname = a.Firstname,
                    Address1 = a.Address1,
                    TypeId = a.TypeId,
                    City = a.City,
                    State = a.State,
                    Zip = a.Zip,
                    Mobile = a.Mobile,
                    SpecialtyName = a.ContactType.Name //make a field called SpecialtyName using the contact type name field
                });
