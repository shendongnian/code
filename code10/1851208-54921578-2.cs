    var result = dbContext.Enquiries.Select(enquiry => new
    {
        EnquiryId = enquiry.Id,
        EnquiryNo = enquiry.EnquiryNo,
        EnquiryDate = enquiry.EnquiryDate,
        Status = enquiry.Status,
        // For the followups: take the followUp dates as nullable DateTime
        // and add the EnquiryDate
        FollowUps = enquiry.FollowUps
            .Select(followUp => followUp.FollowUpdate)
            .Cast<DateTime?>()
            .Concat(new DateTime?[] {enquiry.EnquiryDate})
            // take the two newest ones; we don't want null values
            .Where(date => date != null)
            .OrderByDescending(date => date)
            .Take(2)
            .ToList(),
    })
    // move this to local process, so you can use FollowUps to get Next / Last
    .AsEnumerable()
    .Select(fetchedData => new
    {
        EnquiryId = fetchedData.EnquiryId,
        EnquiryNo = fetchedData.EnquiryNo,
        EnquiryDate = fetchedData.EnquiryDate,
        Status = fetchedData.Status,
        // FollowUps are ordered in Descending order. FirstOrDefault is the newest!
        NextFollowUp = enquiry.FollowUps.FirstOrDefault(),
        LastFollowUp = enquiry.FollowUps.LastOrDefault(),
    }
