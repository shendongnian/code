            new Person()
                {
                    Age = 35,
                    Gender = Gender.Male
                }
        })
    select new { Age=p.Age, Gender=p.Gender.ToString() }
    ).ToArray()[0]
);
