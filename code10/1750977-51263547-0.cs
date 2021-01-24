    foreach (DataGridColumn dgc in SearchResultTable.Columns)
    {
        if (dgc is DataGridTextColumn)
        {
            DataGridTextColumn dgtc = (DataGridTextColumn)dgc;
            Binding bo = (Binding)dgtc.Binding;
            string pps = bo.Path.Path;
            if (pps.Equals("DateOfBirth"))
            {
                int idx = SearchResultTable.Columns.IndexOf(dgtc);
                DataGridTextColumn dgtcn = new DataGridTextColumn();
                dgtcn.IsReadOnly = true;
                Binding b = new Binding("DateOfBirth");
                b.StringFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
                dgtcn.Binding = b;
                SearchResultTable.Columns.Insert(idx, dgtcn);
                SearchResultTable.Columns.Remove(dgtc);
                break;
            }
        }
    }
