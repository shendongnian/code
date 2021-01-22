    public MainWindow()
    {
        InitializeComponent();
        var xmlFilePath = @"c:\whatever\XMLFile1.xml";
        XMLData.Source = new Uri(xmlFilePath);
    }
    private void DataGridLic_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
       var xmlSource = XMLData.Source.LocalPath;
       XMLData.Document.Save(xmlSource);
    }
