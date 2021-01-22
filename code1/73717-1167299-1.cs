           private void AddColumn(GridView view, Field fld)
            {
                GridViewColumn col = new GridViewColumn();
                col.Header = fld.Label;
                Binding bnd = new Binding();
                switch (fld.FieldType)
                {
                    case FieldType.DateTime:
                    bnd.Converter = new DateTimeToDateStringConverter();
                    break;
    // or some other converters
                }
                bnd.Path = new PropertyPath(string.Format("Fields[{0}]",
        _table._fields.IndexOf(fld)));  // the string matches what you would use in XAML
                col.DisplayMemberBinding = bnd;
                view.Columns.Add(col);
            }
