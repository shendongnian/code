    // assuming we already have object CurrentSubmission
    var weights = new Dictionary<Submission, int>(); 
    
    // TAGS
    // get submissions sharing the any of the current tags
    var sharedTags = 
      Db.Submissions
        .Where(s => s.SubmissionTags.Any(CurrentSubmission.SubmissionTags))
        .ToList();
    // weight these submissions by adding to dictionary and multiplying the count of intersections with 3
    sharedTags.ForEach(s => {
        weights.Add(s, CurrentSubmission.SubmissionTags.Intersect(s.SubmissionTag).Count() * 3
    }); 
    
    // TITLE
    var words = CurrentSubmission.Title.Split(‘ ‘);
    var sharedTitles = Db.Submissions.Where(s => s.Title.Split(‘ ‘).Any(words));
    sharedTitles.ForEach(s => {
        var weight = s.Title.Split(‘ ‘).Intersect(words).Count() * 2;
        if (weights.Contains(s))
            weights[s] += weight;
        else
            weights.Add(s, weight);
    });  
    // might not actually work, but you get the idea
    return weights.OrderByDescending(s => s.Value).Keys;
