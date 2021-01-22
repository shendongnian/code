    Intermec.Print.LinePrinter lp;
    int escapeCharacter = int.Parse("1b", NumberStyles.HexNumber);
    char[] toEzPrintMode = new char[] { Convert.ToChar(num2), 'E', 'Z' };
    lp = new Intermec.Print.LinePrinter("Printer_Config.XML", "PrinterPB20_40COL");
    lp.Open();
    lp.Write(charArray2); //switch to ez print mode
    string testBarcode = "{PRINT:@75,10:PD417,YDIM 6,XDIM 2,COLUMNS 2, SECURITY 3|ABCDEFGHIJKL|}";
    lp.Write(testBarcode);
            
    lp.Write("{LP}"); //switch from ez print mode back to line printer mode
            
    lp.NewLine();
    lp.Write("Test"); //verify line printer mode is working
