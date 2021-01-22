    if(e.ColumnIndex = 2)
    {
        if(e.Value != null)
        {
            e.Value = New string("*", e.Value.ToString().Length);
        }
    }
