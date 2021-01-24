    int NumOfLabel = Convert.ToInt16(textBox_StockAddQuntity_StockEntry.Text); /* here for example i set to total copy */
    PrintDialog pDlg = new PrintDialog();
    pDlg.Document = printDocument_Barcode;
    pDlg.AllowSelection = true;
    pDlg.AllowSomePages = true;
    pDlg.PrinterSettings.Copies = (short)NumOfLabel;
    printDocument_Barcode.Print();
