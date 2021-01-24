    var theResponse = db.Issue.Select(i => new {
        Issue = i,
        Question = i.Responses.FirstOrDefault(),
        Answer = i.Responses.OrderBy(r => r.Date).Skip(1).FirstOrDefault()
    });
