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
            }
            bnd.Path = new PropertyPath(string.Format("Fields[{0}]",
    _table._fields.IndexOf(fld)));
            col.DisplayMemberBinding = bnd;
            view.Columns.Add(col);
        }
