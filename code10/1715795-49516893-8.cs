        var person = Context.Patients
                              .AsNoTracking()
                              .Include(p=>p.PatientAllocations)
                              .Include(d=>d.DoctorNotes)
                               .Where(p=>p.PatientID==patientID)
                               .ToList();
    
       return Ok(person);
     }
