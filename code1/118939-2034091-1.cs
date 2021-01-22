    var query = db.People
                  .AsEnumerable()
                  .Select(p => new Person { Name = p.Name,
                                            Age = p.Age,
                                            Gender = p.Gender.ToEnum<Gender>() } );
