    var query = dataContext.Repository<ILead>();
            foreach (var tag in tags)
            {
                String tagName = tag;
                query = query.Where(l => dataContext.Repository<ISportsPerPerson>()
                             .Any(tpl => tpl.PersonId.Equals(l.Id) && tpl.Sports.Name.Equals(tagName)));
            }
    // Do something with query resultset :]
