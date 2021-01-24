    object NewItems = null;
    if (ChildEntity is tblLine)
    {
        NewItems = DBContext
            .tblLines
            .Include("tblGroups.tblStations.tblDevices.tblSubDevices.tblSubSubDevices")
            .AsNoTracking()
            .Single(x => x.ID == ((TblBase)ChildEntity).ID);  
    }
    if (ChildEntity is tblGroup)
    {
    .
    .
    .
