     private void Print_Click(object sender, EventArgs e)
        {
            try
            {          
                PrintDialog printDialog1 = new PrintDialog();              
                PrintDocument pd = new PrintDocument();
                
                printDialog1.Document = pd;
                printDialog1.ShowNetwork = true;
                printDialog1.AllowSomePages = true;
                printDialog1.AllowSelection = false;
                printDialog1.AllowCurrentPage = false;
                printDialog1.PrinterSettings.Copies = (short)this.CopiesToPrint;                
                printDialog1.PrinterSettings.PrinterName = this.PrinterToPrint;
                DialogResult result = printDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    PrintReport(pd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrintReport(PrintDocument pd)
        {
            ReportDocument rDoc=(ReportDocument)crvReport.ReportSource;
            rDoc.PrintOptions.PrinterName = pd.PrinterSettings.PrinterName; //This line helps,In case user selects a different printer other than the default selected.
            rDoc.PrintToPrinter(pd.PrinterSettings.Copies, false, pd.PrinterSettings.FromPage, pd.PrinterSettings.ToPage); // In place of Frompage and ToPage put 0,0 to print all pages,however in that case user wont be able to choose selection.
        }
