            var owners =
                from person in People
                join pet in Pets
                on new
                {
                    person.Id,
                    person.Age,
                }
                equals new
                {
                    pet.Id,
                    Age = pet.Age * 2, // owner is twice age of pet
                }
                into pets
                from pet in pets.DefaultIfEmpty()
                select new PetOwner
                {
                    Person = person,
                    Pet = pet,
                };
