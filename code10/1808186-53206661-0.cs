        List<NewPerson> personInf = new List<NewPerson>();
        foreach (var item in peopleNotRegisteredAsStudents)
        {
            var tempItem = people.SingleOrDefault(person => person.BranchCode == item.BranchCode && person.CountryNo == item.CountryNo);
            if (tempItem != null)
            {
                NewPerson newPerson = new NewPerson
                {
                    ID = tempItem.ID,
                    Name = tempItem.Name,
                    CountryNo = tempItem.CountryNo,
                    Age = tempItem.Age,
                    BranchCode = tempItem.BranchCode,
                    Situation = 0
                };
                personInf.Add(newPerson);
            }
        }
