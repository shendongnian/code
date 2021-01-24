    var personCount = from r in range
        select new
        {
            r.ID,
            NumberOfPersonsInRange = person.Count(p =>
                p.Surname.IsInRange(r.StartRange, r.EndRange, true))
        };
