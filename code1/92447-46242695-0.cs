    Button newBtn = new Button();
    newBtn.AddHandler(Button.ClickEvent, new RoutedEventHandler(BtTable_Click));
    newBtn.AddHandler(Button.PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(BtTable_MouseLeftButtonDown));
    newBtn.AddHandler(Button.PreviewMouseLeftButtonUpEvent, new MouseButtonEventHandler(BtTable_MouseLeftButtonUp));
    newBtn.AddHandler(Button.PreviewMouseMoveEvent, new MouseEventHandler(BtTable_MouseMove));
