    MyTextBox.PreviewTextInput += (sender, args) =>
    {
        if (!int.TryParse(args.Text, out _))
        {
            args.Handled = true;
        }
    };
    DataObject.AddPastingHandler(MyTextBox, (sender, args) =>
    {
        var isUnicodeText = args.SourceDataObject.GetDataPresent(DataFormats.UnicodeText, true);
        if (!isUnicodeText)
        {
            args.CancelCommand();
        }
        var data = args.SourceDataObject.GetData(DataFormats.UnicodeText) as string;
        if (!int.TryParse(data, out _))
        {
            args.CancelCommand();
        }
    });
