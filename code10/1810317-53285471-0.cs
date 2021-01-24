    var desiredCat = cats
            .Select(c => new {
                Rating = 
                    Convert.ToInt32(c.Age == desiredAge) +       // Here you check first criteria
                    Convert.ToInt32(c.Name == desiredName) +     // Check second
                    Convert.ToInt32(c.Babys.Count(b => b.Name == desiredKitten) > 0),   // And the third one
                c })
            .OrderByDescending(obj => obj.Rating) // Here you order them by number of matching criteria
            .Select(obj => obj.c) // Then you select only cats from your custom object
            .First(); // And get the first of them
