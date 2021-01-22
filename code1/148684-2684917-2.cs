    public static int CheckForDRIID(int personID)
    {
        using (var context = ConnectDataContext.Create())
        {
            int masterIndex =
                (from applicationAssociation in context.tblApplicationAssociations
                 where applicationAssociation.ApplicationID == 1 && applicationAssociation.PersonID == personID
                 select int.Parse(applicationAssociation.PersonApplicationID)).DefaultIfEmpty(-1).Single();
            return masterIndex;
        }
    }
