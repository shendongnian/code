    var query = from p in db.Parents
            select new ParentModel()
            {
                FullName = p.LastName + ", " + p.FirstName,
                Children = p.Clildren.Select(a => new ChildModel() 
                            {
                                FullName = a.FirstName + " " + a.LastName,
                                SpiritAnimalDescription = sa.Description
                            }).ToList()
            };
