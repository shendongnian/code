        var list = (from i in Enumerable.Range(1, numberOfGuests)
            select new Guest 
            {
              Id = i,
              Title = "Mr.",
              Firstname = "Test",
              Surname = "Test"
            }).ToList();
