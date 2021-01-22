    var chunks = new List<List<InvestorMailing>>();
    int maxAttachmentsSize = 10;
    foreach (InvestorMailing mail in mailingList)
    {
        var chunkWithSpace = chunks
            .Where(list => list.Sum(x => x.AttachmentSize) +
                           mail.AttachmentSize <= maxAttachmentsSize)
            .FirstOrDefault();
        if (chunkWithSpace != null)
        {
            chunkWithSpace.Add(mail);
        } else {
            chunks.Add(new List<InvestorMailing> { mail });
        }
    }
