    pointScores = contestResults.Where(a => a.contestId == contest.id)
                 .Select((v, i) => new ContestResult
                 {
                     ContestId = v.ContestId,                                                            
                     Points = v.Points,
                     TimeStamp = v.TimeStamp,
                     Position = db.ContestResults
                                .Where(a => a.ContestId == contest.id)
                                .Count(p => p.Points > v.Points || 
                                (p.Points == v.Points && p.TimeStamp < v.TimeStamp)) + 1
                 }).ToList();
