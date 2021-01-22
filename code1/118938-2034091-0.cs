    var query = db.People
                  .Select(p => new { p.Name, p.Age, p.Gender } )
                  .AsEnumerable()
                  .Select(p => new Person { Name = p.Name,
                                            Age = p.Age,
                                            Gender = p.Gender.ToEnum<Gender>() } );
