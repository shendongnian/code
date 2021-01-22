    public static IEnumerable<IEnumerable<DataRow>> Chunkify(
        this DataTable dataTable, int chunkSize)
    {
        for (int i = 0; i < dataTable.Rows.Count; i += chunkSize)
        {
            yield return GetChunk(i, Math.Min(i + chunkSize, dataTable.Rows.Count));
        }
        IEnumerable<DataRow> GetChunk(int from, int toExclusive)
        {
            for (int j = from; j < toExclusive; j++)
            {
                yield return dataTable.Rows[j];
            }
        }
    }
