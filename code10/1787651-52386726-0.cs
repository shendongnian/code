    if (e.PropertyName.Contains("Date"))
    {
        DataGridTextColumn dgtc = e.Column as DataGridTextColumn;
        dgtc.Binding = new Binding(e.PropertyName) { StringFormat = "yyyy-MM-dd" };
    }
