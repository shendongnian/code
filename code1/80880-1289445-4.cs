    IQueryable<Committee> GetCommittees(int? committeeID, int? employeeID, int? committeeTypeID)
    {
        var result = db.Committees.Select(c => c);
        
        if(committeeID.HasValue)
        {
            result = result.Where(c => c.ID = committeeID);
        }
        else if(employeeID.HasValue)
        {
            result = from R in result
                     join C in db.Employees.Where(e => employeeID == e.ID)
                       on R.PID equals C.PID
                     select R;
        }
        else if(committeeTypeID.HasValue)
        {
            result = from R in result
                     join K in db.CommitteeTypes.Where(ct => committeeTypeID == ct.ID)
                       on R.PID equals K.PID
                     select R;
        }
        
        return result;
    }
