    var personEmails = personsRepository
    	.Query()
        .Select(x => new PersonDto
        {
            Name = x.Name,
            Emails = x.Emails.Select(y => y.Email),
        }).ToList();
    	
    var personPhones = personsRepository
    	.Query()
        .Select(x => new PersonDto
        {
            Name = x.Name,
            Phones = x.Phones.Select(y => y.Number),
        }).ToList();	
