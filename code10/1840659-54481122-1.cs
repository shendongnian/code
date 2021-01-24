    PrintDocument pd = new PrintDocument();
    pd.PrintPage += new PrintPageEventHandler(this.PrintTextFileHandler);
    PrintDialog pdialog = new PrintDialog();
    pdialog.Document = pd;
    if (pdialog.ShowDialog() == DialogResult.OK)
    {
        pd.Print();
    }
