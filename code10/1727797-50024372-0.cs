    dt.Setters.Add(new Setter(DataGridCell.MarginProperty, new Binding()
    {
        Path = new PropertyPath("StatusColumnMargin"),
        Mode = BindingMode.OneWay,
        Source = this
    }));
