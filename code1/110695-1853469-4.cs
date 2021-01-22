    private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                streamToPrint = new System.IO.StreamReader
                   (@"F:\temp\labTest.txt");
                try
                {
                    printFont = new Font("Arial", 10);
                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings.PrinterName = "doPDF v6";//<-------added
                    pd.PrintPage += new PrintPageEventHandler
                       (this.pd_PrintPage);
                    pd.Print();
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
