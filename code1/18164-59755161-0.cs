    public void tableFromDatabase(Document doc, Application word, string risk, string bookmarkName, TableTemplate table) {
            Table newTable;//Create a new table
            Range wrdRng = doc.Bookmarks.get_Item(bookmarkName).Range;//Get a bookmark Range
            doc.Bookmarks[bookmarkName].Select();
            newTable = word.Selection.Tables.Add(wrdRng,1,1);//Add new table to selected bookmark by default set 1 row, 1 column (need set interval 1-63)
            newTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;
            newTable.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
            int a=0, b=0;//Set integer values for iterate in model arrays
            //Iterate model rows
            for (int i = 1; i <= table.Rows.Count; i++)//Set in 1 the value because in word tables the begin is (1,1)
            {
                //Only add rows if is after first row
                if (i > 1)
                {
                    newTable.Rows.Add();
                }
                //Terate model columns from rows
                for (int j = 1; j <= table.Rows[a].Columns.Count; j++)
                {
                    //Only Add rows if is after first
                    if (j == 1 && i == 1)
                    {
                        newTable.Cell(i, j).Range.Font.Name = table.Rows[a].Columns[b].cellFontName;
                        newTable.Cell(i, j).Range.Font.Size = table.Rows[a].Columns[b].cellFontSize;
                        newTable.Cell(i, j).Width = float.Parse(table.Rows[a].Columns[b].cellWidth);
                    }
                    else
                    {
                        //Add Cells to rows only if columns of the model is largen than table, this is for not exceed the interval
                        if (newTable.Rows[i].Cells.Count < table.Rows[a].Columns.Count)
                        {
                            newTable.Rows[i].Cells.Add();
                        }
                        //Set the values to new table
                        //The width must be float type
                        newTable.Cell(i, j).Range.Font.Name = table.Rows[a].Columns[b].cellFontName;
                        newTable.Cell(i, j).Range.Font.Size = table.Rows[a].Columns[b].cellFontSize;
                        newTable.Cell(i, j).Width = float.Parse(table.Rows[a].Columns[b].cellWidth);
                    }
                    b++;
                    //Set 0 to reset cycle
                    if (b == table.Rows[a].Columns.Count)
                    {
                        b = 0;
                    }
                }
                a++;
                //Set 0 to reset cycle
                if (a == table.Rows.Count)
                {
                    a = 0;
                }
            }
            newTable.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            newTable.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            newTable.AllowAutoFit = true;
            //Set gray color to borders
            newTable.Borders.InsideColor = (Microsoft.Office.Interop.Word.WdColor)12964311;
            newTable.Borders.OutsideColor = (Microsoft.Office.Interop.Word.WdColor)12964311;
        }
