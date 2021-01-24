     context.Specializations.AddOrUpdate(
            s =>  s.SpecializationID , DummyData.getSpecializations().ToArray());
        context.SaveChanges();
        context.Patients.AddOrUpdate(
            p => p.PatientID, DummyData.getPatients().ToArray());
        context.SaveChanges();
        context.Doctors.AddOrUpdate(
            d => d.DoctorID, DummyData.getDoctors(context).ToArray());
        context.SaveChanges();
