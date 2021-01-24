    public void FillArray(SectionType secType, TableSectionData data, int numberOfColumns, int numberOfRows, string[,] values, ViewSchedule schedule)
    {
        string[,] values = new string[numberOfRows,numberOfColumns];
        for (int r = data.FirstRowNumber; r < numberOfRows; r++)
            {
                for (int c = data.FirstColumnNumber; c < numberOfColumns; c++)
                {
                    values[r, c] = schedule.GetCellText(secType, r, c);
                }
            }
    return values;
    }
