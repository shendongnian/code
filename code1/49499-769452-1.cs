    private List<List<DataRow>> ChunkifyTable(DataTable table, int chunkSize)
    {
        List<List<DataRow>> chunks = new List<List<DataRow>>();
        for (int i = 0; i <= table.Rows.Count / chunkSize; i++)
        {
            chunks.Add(table.AsEnumerable().Skip(i * chunkSize).Take(chunkSize).ToList());
        }
        return chunks;
    }
