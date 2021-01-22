    foreach(var c in GridView1.Columns
                                  .OfType<DataControlField>()
                                  .Where(c => GridView1.Columns.IndexOf(c) > 1))
    {
        c.Visible = false;
    }
