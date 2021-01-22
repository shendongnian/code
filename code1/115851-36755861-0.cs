    PrintDialog printDialog = new PrintDialog();
    if (printDialog.ShowDialog() == true)
    {
        ContentControl contentControl = new ContentControl { Content = ((ViewModelClass)DataContext)PrintableViewModelProperty};
        // This part with the margins is not strictly relevant to your question per se,
        // but it's useful enough to be worth including here for future reference
        PageImageableArea area = printDialog.PrintQueue.GetPrintCapabilities(printDialog.PrintTicket).PageImageableArea;
        contentControl.Margin = new Thickness(area.OriginWidth, area.OriginHeight,
            printDialog.PrintableAreaWidth - area.ExtentWidth - area.OriginWidth,
            printDialog.PrintableAreaHeight - area.ExtentHeight - area.OriginHeight);
        // This shows retrieving the data template which is declared using the DataType
        // property. Of course, if you simply declare a key and reference it explicitly
        // in XAML, you can just use the key itself here.
        DataTemplateKey key = new DataTemplateKey(typeof(MazeViewModel));
        contentControl.ContentTemplate = (DataTemplate)FindResource(key);
        printDialog.PrintVisual(contentControl, "MazeGenerator");
    }
