    public List<RequestedStatusC> GetStatus(DB_Entities DB, string CurrentStatus)
    {            
        List<RequestedStatusC> SR = new List<RequestedStatusC>();
        SR = DB.Database.SqlQuery<RequestedStatusC>(@"SELECT CurrentStatus
                                                        FROM MyTable
                                                        WHERE CurrentStatus = {0}
                                                        ORDER BY StatusKey", CurrentStatus).ToList();
        //if (!SR.Any()) SR.Add(new RequestedStatusC { CurrentStatus = (CurrentStatus == "" ? "Missing" : CurrentStatus) });
        return SR;
    }
