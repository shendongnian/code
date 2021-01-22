    public Window1()
    {
        InitializeComponent();
        // "tb" is a TextBox
        DataObject.AddPastingHandler(tb, OnPaste);
    }
    private void OnPaste(object sender, DataObjectPastingEventArgs e)
    {
        var isText = e.SourceDataObject.GetDataPresent(System.Windows.DataFormats.Text, true);
        if (!isText) return;
        var text = e.SourceDataObject.GetData(DataFormats.Text) as string;
        ...
    }
