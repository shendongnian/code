     private void Print_Click(object sender, EventArgs e)
        {
            try
            {          
                PrintDialog printDialog1 = new PrintDialog();              
                PrintDocument pd = new PrintDocument();
                printDialog1.Document = pd;
                printDialog1.ShowNetwork = true;
                printDialog1.AllowSomePages = true;
                **printDialog1.PrinterSettings.Copies = (short)this.CopiesToPrint;** //This line does exactly what i wanted.
                **printDialog1.PrinterSettings.PrinterName = this.PrinterToPrint;** //This is to change default printer.
                DialogResult result = printDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    PrintReport();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PrintReport()
        {
            ReportDocument rDoc=(ReportDocument)crvReport.ReportSource;            
            rDoc.PrintToPrinter(this.CopiesToPrint, false, 0, 0);
        }
