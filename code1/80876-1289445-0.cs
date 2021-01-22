    IQueryable<Committee> GetCommittees(int? committeeID, int? employeeID, int? committeeTypeID)
    {
        var result = from R in db.Committees.Where(c => committeeID == null || committeeID == c.ID)
                     join C in db.Employees.Where(e => employeedID == null || employeeID == e.ID)
                       on R.PID equals C.PID
                     join K in db.CommitteeTypes.Where(c => committeeTypeID == null || committeeTypeID == c.ID)
                       on R.PID equals K.PID
                     select R;
    }
