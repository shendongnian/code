    private static int GetWidthInPixels(ExcelRange cell)
    {
    	double columnWidth = cell.Worksheet.Column(cell.Start.Column).Width;
    	Font font = new Font(cell.Style.Font.Name, cell.Style.Font.Size, FontStyle.Regular);
    
    	double pxBaseline = Math.Round(MeasureString("1234567890", font) / 10);
    
    	return (int)(columnWidth * pxBaseline);
    }
