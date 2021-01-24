    var query = from p in db.Parents
                select new ParentModel
                {
                    FullName = p.LastName + ", " + p.FirstName,
                    Children = db.Children.Where(c => c.Parent_Id == p.Id)
                        .Select(c => new ChildModel
                        {
                            FullName = c.FirstName + " " + c.LastName,
                            SpiritAnimalDescription = db.SpiritAnimals
                                .FirstOrDefault(sa => sa.Id == c.SpiritAnimal_Id).Description
                        })
                };
