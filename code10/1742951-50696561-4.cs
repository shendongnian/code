    class RangeCollection
    {
    	List<IRangeID> _cells;
    	
    	int IndexOf(ulong rangeID)
    	{
    		return Array.BinarySearch(...);
    	}
    }
    
    class ExcelCell : IRangeID
    {
    	ulong RangeID
    	{
    		get
    		{
    			return GetCellID(_worksheet.SheetID, Row, Column);
    		}
    	}
    
    	ulong GetCellID(int SheetID, int row, int col)
    	{
    		return ((ulong)SheetID) + (((ulong)col) << 15) + (((ulong)row) << 29);
    	}
    }
