    int numberOfColumns = int.MinValue;
    
    foreach (List<object> outputColumns in outputRows)
    {
            if (numberOfColumns < outputColumns.Count)
            { numberOfColumns = outputColumns.Count; }
    }
