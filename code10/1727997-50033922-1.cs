    var allSurveys = ( 
        from s in _context.SadSurveys
        select new SurveyDTO { Id = s.Id, Name = s.User.Name, SubmittedOn = s.Audit.SubmittedOn }
        ).Concat(
        from s in _context.FunSurveys
        select new SurveyDTO { Id = s.Id, Name = s.User.Name, SubmittedOn = s.Audit.SubmittedOn })
        ).ToList();
