    var resultsGroupedByMembers = validationResults
        .SelectMany(
             _ => _.MemberNames.Select(
                x => new {MemberName = x ?? "", 
                          Error = _.ErrorMessage}))
        .GroupBy(_ => _.MemberName);
    
    foreach (var member in resultsGroupedByMembers)
    {
        ModelState.AddModelError(
            member.Key,
            string.Join(". ", member.Select(_ => _.Error)));
    }
