    var c = new DataGridTextColumn();
    c.Header = myProperty;
    if (thisColumnsIsDate())
    {
        myDateTimeProperty = DateTime.Parse(myProperty);
        c.Binding = new Binding(myDateTimeProperty);
        c.Binding.StringFormat = "{0:dd/MM/yyyy}";
        c.SortMemberPath = myDateTimeProperty;
    }
    else
    {
        c.Binding = new Binding(myProperty);
        c.Binding.StringFormat = "{0:dd/MM/yyyy}";
        c.SortMemberPath = myProperty;
    }
    myGrid.Columns.Add(c);
