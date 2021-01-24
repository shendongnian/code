    public bool TryGetScoreLabelNames(out string[] names, string scoreColumnName = DefaultColumnNames.Score)
    {
        names = (string[])null;
        Schema outputSchema = model.GetOutputSchema(dataView.Schema);
        int col = -1;
        if (!outputSchema.TryGetColumnIndex(scoreColumnName, out col))
            return false;
        int valueCount = outputSchema.GetColumnType(col).ValueCount;
        if (!outputSchema.HasSlotNames(col, valueCount))
            return false;
        VBuffer<ReadOnlyMemory<char>> vbuffer = new VBuffer<ReadOnlyMemory<char>>();
        outputSchema.GetMetadata<VBuffer<ReadOnlyMemory<char>>>("SlotNames", col, ref vbuffer);
        if (vbuffer.Length != valueCount)
            return false;
        names = new string[valueCount];
        int num = 0;
        foreach (ReadOnlyMemory<char> denseValue in vbuffer.DenseValues())
            names[num++] = denseValue.ToString();
        return true;
    }
