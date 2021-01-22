    object[] allCellValues = new object[stringArray.Length];
    for (int r = 0; r < stringArray.GetLength(0); r++) {
        for (int c = 0; c < stringArray.GetLength(1); c++) {
            allCellValues[r, c] = stringArray[r,c] as object;
        }
    }
    return allCellValues;
