    List<Person> pr = db.Persons
                        .Join(db.PersonExceptions,
                              p => p.ID,
                              e => e.PersonID,
                              (p, e) => new { p, e })
                        .Where(z => z.e.CreatedOn >= fromDate)
                        .OrderByDescending(z => z.e.CreatedOn)
                        .Select(z => z.p)
                        .ToList();
