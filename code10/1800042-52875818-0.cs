    Style style = new Style();
    style.Setters.Add(new EventSetter(Hyperlink.ClickEvent, new RoutedEventHandler(hyperlink_Click)));
    DataGridHyperlinkColumn parent = new DataGridHyperlinkColumn
    {
        Header = "Path",
        Binding = new Binding("FullPath"),
        ContentBinding = new Binding("Name"),
        IsReadOnly = true,
        ElementStyle = style
    };
