    private void button1_Click(object sender, EventArgs e) 
    {
        //C1 is a cell I use to evaluate the Format of Cells A1 thru to A7
        using (var rnEvaluate = xlApp.Range["C1:C1"].WithComCleanup())
        {
            for (int i = 1; i < 8; i++)
            {
                rnEvaluate.Resource.Value2 = "=CELL(\"format\",A" + i.ToString() + ")";
                string cellFormat = GetExcelCellFormat(rnEvaluate.Resource.Value2);
                System.Diagnostics.Debug.Write(cellFormat);
            }
        } 
    }
    
    private string GetExcelCellFormat(string cellFormat = "G") 
    {
        switch (cellFormat.Substring(0, 1))
        {
            case "F" :
                return "Number";
                break;
            case "C":
                return "Currency";
                break;
            case "D":
                return "Date";
                break;
            default :
                return "General";
                break;
        } 
    }
