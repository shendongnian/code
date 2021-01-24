    private Table CreateTable(Dictionary<string, IEnumerable<string>> data)
    {
        ////
        // New table instance
        ////
        _requiredColumns = data.Count + 1;
        Table table = new Table()
        {
            Name = "tableDay",
            Docking = DockingStyle.Fill,
            Location = new PointU(Unit.Cm(0D), Unit.Cm(0D)),
            Size = new SizeU(Unit.Cm(17D), Unit.Cm(5D)),
            RowHeadersPrintOnEveryPage = true
        };
        table.Bindings.Add(new Telerik.Reporting.Binding("DataSource", "= Fields.Rows"));
        for (int i = 0; i < _requiredColumns; i++)
        {
            table.Body.Columns.Add(new TableBodyColumn(Unit.Cm(_columnWidth)));
        }
        ////
        // Add headers
        ////
        table.ColumnGroups.Add(new TableGroup
        {
            Name = "columnLeftMost",
            ReportItem = new TextBox { Name = "textBoxHours", Value = "Hours" }
        });
        foreach (var item in data)
        {
            table.ColumnGroups.Add(new TableGroup
            {
                Name = "column" + item.Key,
                ReportItem = new TextBox { Name = "textBoxTitleDay" + item.Key, Value = item.Key }
            });
        }
        ////
        // Add data rows
        ////
        var tableGroup28 = new TableGroup() { Name = "tableGroup280" };
        tableGroup28.Groupings.Add(new Telerik.Reporting.Grouping(null));
        table.RowGroups.Add(tableGroup28);
        table.Body.Rows.Add(new TableBodyRow(Unit.Cm(ROWHEIGHT)));
        List<ReportItemBase> list = new List<ReportItemBase>();
        for (int i = 0; i < _requiredColumns; i++)
        {
            var tb = new TextBox
            {
                Name = "textBox" + i,
                Value = i == 0 ? "= Fields.DayTimeFriendly" : "= Fields.RowValues"
            };
            list.Add(tb);
            table.Body.SetCellContent(0, i, tb);
        }
        table.Items.AddRange(list.ToArray());
        return table;
    }
