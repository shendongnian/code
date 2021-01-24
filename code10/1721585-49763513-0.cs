    GetPhoneList()
        .GroupBy(x => x.PersonID)
        .Select(x => x.Aggregate(new Person() { PersonID = x.Key },
            (person, phone) =>
            {
                switch (phone.Type)
                {
                    case PhoneType.Home: person.HomePhone = phone; break;
                    case PhoneType.Work: person.WorkPhone = phone; break;
                    case PhoneType.Cell: person.CellPhone = phone; break;
                }
                return person;
            }));
