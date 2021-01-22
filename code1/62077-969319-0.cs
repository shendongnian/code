    int colIndex = 0;
    int x = listView1.Columns[0].Width;
    bool inRange = true;
    while (x < e.X)
    {
        colIndex++;
        if (colIndex >= listView1.Columns.Count)
        {
            inRange = false;
            break;
        }
        x += listView1.Columns[colIndex].Width;    
    }
    if (inRange)
    {
        // colIndex contains the column index
    }
    else
    {
        // the mouse was not inside any column
    }
