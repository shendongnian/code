    Style itemContainerStyle = new Style(typeof(ListBoxItem));
    itemContainerStyle.Setters.Add(new Setter(AllowDropProperty, true));
    itemContainerStyle.Setters.Add(new EventSetter(PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(s_PreviewMouseLeftButtonDown)));
    itemContainerStyle.Setters.Add(new EventSetter(DropEvent, new DragEventHandler(listbox1_Drop)));
    listbox1.ItemContainerStyle = itemContainerStyle;
