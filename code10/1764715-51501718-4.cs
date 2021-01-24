        var datagrid = new DataGrid {AutoGenerateColumns = false};
        Grid.SetRow(datagrid,1);
        RootGrid.Children.Add(datagrid);
        var templateColumn = new DataGridTemplateColumn
        {
            Header = "My column",
            IsReadOnly = true
        };
        var cellTemplate = new DataTemplate();
        var factory = new FrameworkElementFactory(typeof(TextBlock));
        factory.SetBinding(TextBlock.TextProperty, new Binding("Foo"));
        var style = new Style(typeof(DataGridCell));
        var trigger = new DataTrigger();
        var triggerBinding = new Binding("DataContext.IsChecked")
        {
            RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(DataGrid), 1)
        };
        trigger.Binding = triggerBinding;
        trigger.Value = true;
        var triggerSetter = new Setter {Property = ContentTemplateProperty};
        var triggerTemplate = new DataTemplate();
        var anotherFactory = new FrameworkElementFactory(typeof(TextBlock));
        anotherFactory.SetValue(TextBlock.TextProperty,"lol");
        triggerTemplate.VisualTree = anotherFactory;
        triggerSetter.Value = triggerTemplate;
        trigger.Setters.Add(triggerSetter);
        style.Triggers.Add(trigger);
        templateColumn.CellStyle = style;
        cellTemplate.VisualTree = factory;
        templateColumn.CellTemplate = cellTemplate;
        datagrid.Columns.Add(templateColumn);
        datagrid.ItemsSource = Items;
