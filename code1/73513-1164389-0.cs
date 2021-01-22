    var newCol = new DataGridTextColumn();
    newCol.Binding = new Binding("SdDevDuration");
    var visiblityBinding = new Binding("IsVisible");
    visiblityBinding.Source = col;
    visiblityBinding.Converter = new VisibilityConverter();                        
    BindingOperations.SetBinding(newCol, DataGridTextColumn.VisibilityProperty, visiblityBinding);
