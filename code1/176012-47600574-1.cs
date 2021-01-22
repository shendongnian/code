    private static int CellReferenceToIndex(Cell cell)
    {
        int index = -1;
        string reference = cell.CellReference.ToString().ToUpper();
        foreach (char ch in reference)
        {
            if (Char.IsLetter(ch))
            {
                int value = (int)ch - (int)'A';
                index = (index + 1) * 26 + value;
            }
            else
                return index;
        }
        return index;
    }
