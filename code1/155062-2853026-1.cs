    foreach (var column in columns)
    {
        var dataColumn =
            new DataGridTextColumn
                {
                    Header = column.Caption,
                    Binding = new Binding(column.FieldName),
                    CellStyle = 
                    new Style
                        {
                            TargetType = typeof (DataGridCell),
                            Triggers =
                                {
                                    new DataTrigger
                                        {
                                            Binding = new Binding(column.FieldName + ".IsDirty"),
                                            Setters =
                                                {
                                                    new Setter
                                                        {
                                                            Property = Control.BackgroundProperty,
                                                            Value = Brushes.Yellow,
                                                        }
                                                }
                                        }
                                }
                        }
                };
        _dataGrid.Columns.Add(dataColumn);
    }
