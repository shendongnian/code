    var groupedMailings = mailingList.GroupBy(g => g.To);
    var investorMailings = groupedMailings.Select(
        g => new 
        { 
            To = g.Key,
            Attachments = g.Select(k => k.AttachmentPath),
            Count = g.Sum(j => j.AttachmentCount) 
        }
    );
