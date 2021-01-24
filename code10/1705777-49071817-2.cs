    var data = Connection.Families   //main table
                    .Where(x => some conditions)
                    .GroupJoin(Connection.Cars   //left outer join
                        , f => f.ID   //join condition
                        , c => c.FamilyID // join condition
                        , (f, c) => new {Family = f, CarNames = c.Select(o => o.Name)})
                        .OrderByDescending(d => d.Family.ID)
                        .ToList()
                        .Select(o => new Families
                        {
                            Id = o.Family.ID,
                            Surname = o.Family.SurName,
                            Address = o.Family.Address,
                            // Check possible null from left join
                            Cars = o.CarNames.Count() > 0 ? o.CarNames.Aggregate((a, b) => a + "," + b) : string.Empty
                        })                    
                    .ToList();
