    ...
    dgCreateOperationsData.ItemsSource = _operationEntryList;
    dgCreateOperationsData.AutoGeneratingColumn += (s, e) =>
    {
        FrameworkElementFactory fe = new FrameworkElementFactory(typeof(ContentControl));
        fe.SetBinding(ContentControl.ContentProperty, new Binding(e.PropertyName));
        e.Column = new DataGridTemplateColumn()
        {
            CellTemplate = new DataTemplate() { VisualTree = fe }
        };
    };
