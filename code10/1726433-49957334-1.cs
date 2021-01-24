    enum CellType : byte
    { Date, Teams, Value, Text }
    
    static class CellCheckFactory
    {
        ICellCheck Create(CellType cellType)
        {
            switch(cellType)
            {
                case CellType.Date:
                    return new DateCellCheck();
                case CellType.Teams:
                    return new TeamCellCheck();
                case CellType.Value:
                    return new ValueCellCheck();
                case CellType.Text:
                    return new TextCellCheck();
            }
        }
    }
