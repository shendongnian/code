            private void button1_Click(object sender, EventArgs e)
            {
                PrintDialog printdg = new PrintDialog();
                if (printdg.ShowDialog() == DialogResult.OK)
                {
                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings = printdg.PrinterSettings;
                    pd.PrintPage += PrintPage;
                    pd.Print();
                    pd.Dispose();
                }
            }
            private void PrintPage(object o, PrintPageEventArgs e)
            {
               // Printng logic
            }
