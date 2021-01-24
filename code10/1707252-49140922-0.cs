    //create a list with the rows already split by comma
    List<string[]> allRows = File.ReadLines(Server.MapPath("/textfile1.txt")).Select(line => line.Split(',')).ToList();
    
    //group by weekday
    var sortedList = allRows.GroupBy(x => x[1]).ToList();
    
    //get the max number of rows needed
    var rowCount = sortedList.Max(x => x.Count()) + 1;
    
    //create a new table
    Table table = new Table();
    
    //fill the table with rows and columns
    for (int i = 0; i < rowCount; i++)
    {
        TableRow row = new TableRow();
    
        for (int j = 0; j < (sortedList.Count * 2); j++)
        {
            //if it is the first row add the row headers
            if (i == 0)
            {
                row.BackColor = Color.LightGray;
    
                if (j % 2 == 1)
                    row.Cells.Add(new TableCell() { Text = sortedList[j /2].Key });
                else
                    row.Cells.Add(new TableCell() { Text = "Nr" });
             }
             else
             {
                row.Cells.Add(new TableCell());
            }
        }
    
        table.Rows.Add(row);
    }
    
    //loop all the weekdays
    for (int i = 0; i < sortedList.Count; i++)
    {
        int j = 1;
    
        //loop all the items within a weekday
        foreach (var item in sortedList[i])
        {
            //the item[x] is based on the sample txt file, it is the row split by comma index
            table.Rows[j].Cells[i * 2].Text = item[2];
            table.Rows[j].Cells[(i * 2) + 1].Text = item[3];
            j++;
        }
    }
