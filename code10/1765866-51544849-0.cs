    private (int[,], string[]) SortByColumnNames(int[,] array, string[] columnNames)
    {
        var columnNameToIndex = columnNames.Select((c, index) => Tuple.Create(c, index));
        var sortedColumns = columnNameToIndex.OrderBy(ci => ci.Item1, StringComparer.OrdinalIgnoreCase).ToList();
        var sortedArray = new int[2, 3];
        for (var newColumnIndex = 0; newColumnIndex < sortedColumns.Count; newColumnIndex++)
        {
            var oldColumnIndex = sortedColumns[newColumnIndex].Item2;
            for (var rowIndex = 0; rowIndex < array.GetLength(1); rowIndex++)
            {
                sortedArray[newColumnIndex, rowIndex] = array[oldColumnIndex, rowIndex];
            }
        }
        var resultColumnNames = sortedColumns.Select(ci => ci.Item1).ToArray();
        return (sortedArray, resultColumnNames);
    }
