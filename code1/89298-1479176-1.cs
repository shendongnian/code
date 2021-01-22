    private void CellsChange(Excel.Range Target) 
    {
        if ((this.Application.Selection as Excel.Range) != null)
        {
            Excel.Range selectedRange = thisAddIn.Application.Selection as Excel.Range;
            if (selectedRange.Rows.Count > 1)
            {
                //put your code to handle autofill here
            }
        }
    }
