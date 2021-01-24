    if (question.Id == 0) 
    {
        foreach(var tech in question.Technologies)
            _context.Technologies.Attach(tech)
        _context.Questions.Add(question);
    }
    else
    {
        var questionInDb = _context.Questions.Single(q => q.Id == question.Id);
        questionInDb.Name= question.Name;
        questionInDb.CountryId = question.CountryId;
        
        foreach(var tech in question.Technologies.Where(t => !questionInDb.Technologies.Any(x => x.Id == t.Id)))
            _context.Technologies.Attach(tech);
        //Remove Technologies that have been unchecked in the page
        //...
    }
