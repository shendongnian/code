     public static Range SpecialCellsCatchError(this Range myRange, XlCellType cellType)
        {
            try
            {
                return myRange.SpecialCells(cellType);
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                return null;
            }
        }
