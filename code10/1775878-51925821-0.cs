    public DataTable CopyDataTable(DataTable dtSource)
    {
            // cloned to get the structure of source
            DataTable dtDestination = dtSource.Clone();
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                dtDestination.ImportRow(dtSource.Rows[i]);
            }
            return dtDestination;
    }
