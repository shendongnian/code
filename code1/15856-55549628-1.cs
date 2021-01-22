    private void SetSortArrow(ColumnHeader head, SortOrder order)
    {
        const string ascArrow = " ▲";
        const string descArrow = " ▼";
        // remove arrow
        if(head.Text.EndsWith(ascArrow) || head.Text.EndsWith(descArrow))
            head.Text = head.Text.Substring(0, head.Text.Length-2);
        // add arrow
        switch (order)
        {
            case SortOrder.Ascending: head.Text += ascArrow; break;
            case  SortOrder.Descending: head.Text += descArrow; break;
        }
    }
    SetSortArrow(listView1.Columns[0], SortOrder.None);       // remove arrow from first column if present
    SetSortArrow(listView1.Columns[1], SortOrder.Ascending);  // set second column arrow to ascending
    SetSortArrow(listView1.Columns[1], SortOrder.Descending); // set second column arrow to descending
