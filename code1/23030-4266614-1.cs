    List<AvailabilityIssue> ai = new List<AvailabilityIssue>();
    
    ai.AddRange(
        (from a in db.CrewLicences
            where
                a.ValidationDate <= ((UniversalTime)todayDate.AddDays(30)).Time &&
                a.ValidationDate >= ((UniversalTime)todayDate.AddDays(15)).Time
            select new AvailabilityIssue()
            {
                crewMemberId = a.CrewMemberId,
                expirationDays = 30,
                Name = a.LicenceType.Name,
                expirationDate = new UniversalTime(a.ValidationDate).ToString("yyyy-MM-dd"),
                documentType = Controllers.rpmdataController.DocumentType.Licence
            }).ToList());
