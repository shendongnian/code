    FrameworkElementFactory checkBox = new FrameworkElementFactory( typeof(CheckBox) );
    checkBox.AddHandler( CheckBox.ClickEvent, new RoutedEventHandler( OnCheckBoxClick ) );
    gridView.Columns.Add( new GridViewColumn
    {
        Header = string.Empty,
        CellTemplate = new DataTemplate { VisualTree = checkBox },
    } );
