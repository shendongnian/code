    private static readonly ConvertStringToDBNull _converter = new ConvertStringToDBNull();
    private void dgDt_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        ((DataGridBoundColumn)e.Column).Binding = new Binding(e.PropertyName) { Converter = _converter };
    }
