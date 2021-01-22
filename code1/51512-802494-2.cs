    public void ChangeColumnDefinitions ( IEnumerable<XmlGridColumnDefinition> columns )
    {
        this.datagrid.Columns.Clear ();
        foreach ( var column in columns )
        {
                DataGridTextColumn coldef = new DataGridTextColumn
                {
                        Header = column.Heading,
                        Binding = new Binding ( string.Format ( "Element[{0}].Value", column.FieldName ) )
                };
                this.datagrid.Columns.Add ( coldef );
        }
    }
