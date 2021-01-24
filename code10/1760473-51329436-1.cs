    public IEnumerable<YourObject> GetEm()
    {
        // assume we have your IDataReader named dr
        while (dr.Read())
        {
            yield return GetYourObjectFromDrFunction(dr);
        }
    }
