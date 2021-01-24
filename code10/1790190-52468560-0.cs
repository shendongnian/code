    string[] cellResult = new string[rows_.Length];
    for (int i = 0; i < cr.Length; i++)
    {
        ...
        cellResult[i] = cell[i].ToString(); // Uses always same array cellResult.
    }
