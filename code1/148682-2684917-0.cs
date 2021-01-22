    public static int CheckForDRIID(int personID)
    {
        var someAssociaction = new { ApplicationID = 1, PersonID = 1, PersonApplicationID = 1 };
        var associactions = (new[] { someAssociaction }).ToList();
        associactions.Add(new { ApplicationID = 2, PersonID = 2, PersonApplicationID = 2 });
        int masterIndex =
            (from applicationAssociation in associactions
             where applicationAssociation.ApplicationID == 1 && applicationAssociation.PersonID == personID
             select applicationAssociation.PersonApplicationID).DefaultIfEmpty(-1).Single();
        return masterIndex;
    }
