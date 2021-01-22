    private PrintDocument _printDocument = new PrintDocument();
    private int _checkPrint;
    public Form1()
    {
        InitializeComponent();
        _printDocument.BeginPrint += _printDocument_BeginPrint;
        _printDocument.PrintPage += _printDocument_PrintPage;
    }
    private void btnPrint_Click(object sender, EventArgs e)
    {
        PrintDialog printDialog=new PrintDialog();
        if (printDialog.ShowDialog() == DialogResult.OK)
            _printDocument.Print();
    }
    private void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
    {
        // Print the content of RichTextBox. Store the last character printed.
        _checkPrint = rchEditor.Print(_checkPrint, rchEditor.TextLength, e);
        // Check for more pages
        e.HasMorePages = _checkPrint < rchEditor.TextLength;
    }
    private void _printDocument_BeginPrint(object sender, PrintEventArgs e)
    {
        _checkPrint = 0;
    }
