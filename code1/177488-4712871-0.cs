            public IQueryable<Person> GetPersons()
            {
                var list = context.Persons.select(p=>p).AsEnumerable()
                          .Select(m=>m.MyExtensionMethod());
                return list;
            }
