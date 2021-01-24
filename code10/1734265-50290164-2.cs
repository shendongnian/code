    for (int r = 0, rCount = workSheet.Rows.Count; r < rCount; ++r)
    {
        for (int c = 0, cCount = workSheet.CalculateMaxUsedColumns(); c < cCount; ++c)
        {
            var value = workSheet.Cells[r, c].Value;
            // ...
        }
    }
