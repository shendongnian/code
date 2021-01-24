    var result = dbContext.Patients
        .Where(patient => ...)           // only if you don't want all Patients
        .Select(patient => new
        {
            // Select from every Patient only the properties you plan to use
            Id = patient.Id,
            Name = patient.Name,
            ...
            LastVisitTime = patient.Visits
                .OrderByDescenting(visit => visit.VisitDate)
                .FirstOrDefault(),
        });
