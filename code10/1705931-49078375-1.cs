    emails
        .Where(item =>
           (item.EmailAddress.ToLower() != newEmailAddress.ToLower() && item.IsPrimary)
       .Select(item => { item.IsPrimary = false; return true;})
       .All();
