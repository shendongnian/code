    public IList<string> LookupColumnY(string hex)
    {
         return tblDataTable
                    .Select("Columnx = '" + hex + "'", "Columny ASC")
                    .Select(row => row["Columny"].ToString() )
                    .ToList();
    }
