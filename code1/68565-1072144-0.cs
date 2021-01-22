    if(condition)
    {
        table.Select(x => x.ColumnA);
    }
    else
    {
        table.Select(x => x.ColumnB);
    }
