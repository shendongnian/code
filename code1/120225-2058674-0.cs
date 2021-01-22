    public IQueryable<Clam> getAllClams(int clamTypeID, int? parentClamID)
    {
         return from clam in Clams
                where clam.ClamTypeID == clamTypeID &&
                      object.Equals(clam.ParentClamID, parentClamID)
                select clam;
    }
