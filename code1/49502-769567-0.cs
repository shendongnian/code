    public IEnumerable<IEnumerable<DataRow>> Chunkify(DataTable table, int size)
    {
        List<DataRow> chunk = new List<DataRow>(size);
    
        foreach (var row in table.Rows)
        {
            chunk.Add(row);
            if (chunk.Count == size)
            {
                yield return chunk;
                chunk = new List<DataRow>(size);
            }
        }
    
        if(chunk.Any()) yield return chunk;
    }
