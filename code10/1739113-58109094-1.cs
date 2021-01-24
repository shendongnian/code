            var owners = People.GroupJoin(
                Pets,
                person => new { person.Id, person.Age },
                pet => new { pet.Id, Age = pet.Age * 2 },
                (person, pet) => new
                {
                    Person = person,
                    Pets = pet,
                }).SelectMany(
                pet => pet.Pets.DefaultIfEmpty(),
                (people, pet) => new
                {
                    people.Person,
                    Pet = pet,
                });
