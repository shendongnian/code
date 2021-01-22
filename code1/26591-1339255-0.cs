    public void PrintToPrinter(string printerName)
            {
                PrintDialog pd = new PrintDialog();
                pd.Document = userControl11.PrintDoc; // <--- Update this line with your doc
                pd.PrinterSettings.PrinterName = printerName;
                try
                {
                        pd.Document.DocumentName = "My Label";
                        pd.Document.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("2-.75", 200, 75);
                        pd.Document.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
                        //pd.PrinterSettings.Copies = (short)mNumCopies;
                        pd.Document.PrinterSettings.Copies = (short) mNumCopies;
                        pd.Document.Print();
                }
                catch
                {
                    MessageBox.Show("INVALID PRINTER SPECIFIED");
                }
            }
