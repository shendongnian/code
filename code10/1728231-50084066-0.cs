        public void PrintHtml(string html)
        { 
    textControl1.Load("your file path",StringStreamType.HTMLFormat)
         PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings = new PrinterSettings();
                    pd.PrinterSettings.PrinterName = printerName;
                    textControl1.Text =html;// this line not needed.
                    pd.PrinterSettings.PrintFileName = "d:\\abc.pdf";
                    pd.DefaultPageSettings.PaperSize = new PaperSize("Label", (int)textControl1.PageSize.Width, (int)textControl1.PageSize.Height);
                    pd.DefaultPageSettings.Margins = new Margins((int)textControl1.PageMargins.Left, (int)textControl1.PageMargins.Right, (int)textControl1.PageMargins.Top, (int)textControl1.PageMargins.Bottom);
          pd.DefaultPageSettings.Landscape = false;
         textControl1.Print(pd);
            }
