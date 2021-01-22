    var resultsGroupedByMembers = validationResults
        .SelectMany(vr => vr.MemberNames
                            .Select(mn => new { MemberName = mn ?? "", 
                                                Error = vr.ErrorMessage }))
        .GroupBy(x => x.MemberName);
    
    foreach (var member in resultsGroupedByMembers)
    {
        ModelState.AddModelError(
            member.Key,
            string.Join(". ", member.Select(m => m.Error)));
    }
