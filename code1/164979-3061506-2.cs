    public Window1()
    {
        InitializeComponent();
        // "tb" is a TextBox
        DataObject.AddPastingHandler(tb, OnPaste);
    }
    private void OnPaste(object sender, DataObjectPastingEventArgs e)
    {
        var isText = e.SourceDataObject.GetDataPresent(DataFormats.UnicodeText, true);
        if (!isText) return;
        var text = e.SourceDataObject.GetData(DataFormats.UnicodeText) as string;
        ...
    }
