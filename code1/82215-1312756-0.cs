    DataGridColumn fooColumn =  new DataGridTextColumn 
    {
      Binding = new Binding {Path = new PropertyPath("BindingPath"), 
                             Mode = BindingMode.OneWay}
    };
    
    BindingOperations.SetBinding(fooColumn, DataGridColumn.HeaderProperty, new Binding("Foo") { Source = yourViewModel} );
