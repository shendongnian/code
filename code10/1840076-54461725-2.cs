    var result = dbContext.Patients.GroupJoing(dbContext.Visits,
        patient => patient.Id,             // from every Patient take the Id
        visit => visit.PatientId,          // from every Visit take the PatientId,
        (patient, visits) => new           // use every patient with all his matching Visits
        {                                  // to make a new object
             Id = patiend.Id,
             Name = patient.Name,
             ...
             LastVisit = visits.OrderByDescending(visit => visit.VisitDate)
                         .FirstOrDefault(),
        });
