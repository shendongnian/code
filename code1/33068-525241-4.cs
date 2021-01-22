    var query =
        people.GroupJoin(pets,
                         person => person,
                         pet => pet.Owner,
                         (person, petCollection) =>
                            new { OwnerName = person.Name,
                                  Pet = PetCollection.Select( p => p.Name )
                                                     .DefaultIfEmpty() }
                        ).ToList();
