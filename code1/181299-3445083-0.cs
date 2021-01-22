        //setup the data
        var random = new Random();
        int x = random.Next(14) + 1;
        int y = random.Next(29) + 1;
        var data = new int[x, y];
        for (int i = 0; i < x; i++)
            for (int j = 0; j < y; j++)
                data[i, j] = random.Next(100);
        //create the data table
        var table = new Table();
        for (int i = 0; i < x; i++)
        {
            var newRow = new TableRow();
            for (int j = 0; j < y; j++)
            {
                var newCell = new TableCell();
                newCell.Text = data[i,j].ToString();
                newRow.Cells.Add(newCell);
            }
            table.Rows.Add(newRow);
        }
        ux_Panel.Controls.Add(table);
