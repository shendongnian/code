    //define this somewhere
    System.Globalization.CultureInfo gb = new System.Globalization.CultureInfo("en-GB");
    System.Globalization.CultureInfo us = new System.Globalization.CultureInfo("en-US");
    
    if (oCol.ColumnName == "TotalAmt_Currency1")
                {
                    oWorkSheet.Column(iColNumber).Style.Numberformat.Format=gb.DateTimeFormat.ShortDatePattern.ToString();
                }
                if (oCol.ColumnName == "TotalAmt_Currency2")
                {
                     oWorkSheet.Column(iColNumber).Style.Numberformat.Format=us.DateTimeFormat.ShortDatePattern.ToString();
                }
