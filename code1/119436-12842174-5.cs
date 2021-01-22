    private void BtnPrint_Click(object sender, System.EventArgs e)
    {
        string s = "^XA^LH30,30\n^FO20,10^ADN,90,50^AD^FDHello World^FS\n^XZ";
        
        PrintDialog pd  = new PrintDialog();
        pd.PrinterSettings = new PrinterSettings();
        if(DialogResult.OK == pd.ShowDialog(this))
        {
            RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s);
        }
    }
