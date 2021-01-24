    var item = obj
        .GroupBy(a => a.id)
        .Select(ac =>
            new Final
            {
                Id = ac.Key,
                Details = ac.Select(a =>
                    new classB {interest = a.interest, phone = a.phone, Name = a.Name})
                    .ToList()
            });
