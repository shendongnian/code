    public static IEnumerable<DataRow> getRows(DataTable table)
    {
        foreach (DataRow row in table.Rows)
        {
            yield return row;
        }
    }
    bool isExisting = getRows(bdsAttachments.DataSource as DataTable).Any(xxx => (string)xxx["filename"] == filename);
