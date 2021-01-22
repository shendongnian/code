    private List<List<DataRow>> ChunkifyTable(DataTable table, int chunkSize)
    {
        List<List<DataRow>> chunks = new List<List<DaraRow>>();
        for (int i = 0; i < table.Rows.Count / chunkSize; i++)
        {
            chunks.Add(table.Rows.Skip(i * chunkSize).Take(chunkSize).ToList());
        }
        
        return chunks;
    }
