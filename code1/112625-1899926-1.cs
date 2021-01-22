    internal List<int> GetDoctorsIDs(Predicate<DataRow> doctorFilter)
    {
        var Result = from DataRow doctor in DoctorTable.Rows
                     where doctorFilter(doctor)
                     select doctor.ID
        List<int> Doctors = new List<int>();
        foreach (int id in Result)
        {
             //Register getting data
             Database.LogAccess("GetOldDoctorsID: " + id.ToString());
             if (Database.AllowAccess(DoctorsTable, id))
             {
                 Doctors.Add(id);
             }
        }
    }
