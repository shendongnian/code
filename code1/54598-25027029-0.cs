    var votes = db.Votes.Where(r => r.SurveyID == surveyId);
    if (fromDate != null)
    {
        votes = votes.Where(r => r.VoteDate.Value >= fromDate);
    }
    if (toDate != null)
    {
        votes = votes.Where(r => r.VoteDate.Value <= toDate);
    }
    votes = votes.Take(LimitRows).OrderByDescending(r => r.VoteDate);
