    public static IQueryable<archive> ToIssuingDatesOfUser(this IQueryable<archive> archives,
        string userName)
    {
        // first limit the number of archives, depdning on userName,
        // then select the IssuingDate, remove duplicates, and finally Order
        var archivesOfUser = (userName == null) ? archives :
            archives.Where(archive => archive.InsertedBy == userName);
       return archivesOfUser.Select(archive => archive.IssuingDate)
                            .Distinct()
                            .OrderBy(issuingDate => issuingDate);
    }
