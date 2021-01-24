    dtgWatch.AutoGenerateColumns = false;
    foreach (DataColumn column in dtsWatch.Tables[0].Columns)
    {
        string dataGridTemplateColumn = $@"
        <DataGridTemplateColumn
            Header=""{column.ColumnName}""
            xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
            xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"" >
            <DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                    <ContentControl Content=""{{Binding {column.ColumnName}}}"" />
                </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>";
        XmlReader xr = XmlReader.Create(new StringReader(dataGridTemplateColumn));
        dtgWatch.Columns.Add((DataGridTemplateColumn)System.Windows.Markup.XamlReader.Load(xr)); 
    }
