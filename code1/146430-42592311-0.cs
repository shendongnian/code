        public void CreateTallPeople()
        {
            var tallPeopleList = new List<IPerson>
            {
                new TallPerson {Height = 210, Name = "Stevo"},
                new TallPerson {Height = 211, Name = "Johno"},
            };
            InteratePeople(tallPeopleList);
        }
        public void InteratePeople(List<IPerson> people)
        {
            foreach (var person in people)
            {
                Console.WriteLine($"{person.Name} is {person.Height}cm tall.  ");
            }
        }
