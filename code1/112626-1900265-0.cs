    internal List<int> GetOldDoctorsIDs()
    {
        return GetDoctorsIDs((doctor) => doctor.Age > 30);
    }
    internal List<int> GetExpensiveDoctorsIDs()
    {
        return GetDoctorsIDs((doctor) => doctor.Cost > 30000);
    }
    internal List<int> GetDoctorsIDs(Func<DataRow, bool> Condition)
    {
        var Result = from DataRow doctor in DoctorTable.Rows
                     where Condition(doctor)
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
