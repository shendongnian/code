    // get the rectangle for the first item; used for getting sideways scrolling offset
    Rectangle r = listView1.GetItemRect(0);
    int leftOffset = r.Left;
    
    if (listView1.Columns[0].Width + leftOffset > e.X)
    {
        // first column
    }
    else
    {
        // other column
    }
