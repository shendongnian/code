    public IEnumerable<Report> GetCurrentReportsForStaffByUsername(string username)
    {
        var staffId =
            GetStaffIdFromUsername(username);
    
        var query = (
            from reports in this.DbContext.Reports
            join pupil in this.DbContext.Pupils on reports.PupilID equals pupil.PupilID
            where reports.StaffId == staffId
            select reports)
    
        return query;
    }
