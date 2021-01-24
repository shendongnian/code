        private void button1_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintController = new PrintControllerWithStatusDialog(new BillPrintController(dataGridView1.Rows.Cast<DataGridViewRow>().ToArray()), "Bill Print");
            pd.Print();
        }
