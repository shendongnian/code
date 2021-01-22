    item = new RadMenuItem();
    item.Header = "Hide Column";
    DependencyProperty commProp = RadMenuItem.CommandProperty;
    if (!BindingOperations.IsDataBound(item, commProp)) {
      Binding binding = new Binding("HideColumnCommand");
      BindingOperations.SetBinding(item, commProp, binding);
    }
    //this is optional, i found easier to pass the direct ref of the parameter instead of another binding (it would be a binding to ElementName).
    item.CommandParameter = headerlCell.Column;
    menu.Items.Add(item);
