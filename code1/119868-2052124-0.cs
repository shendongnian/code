    TableHeaderRow row = new TableHeaderRow();
            TableRow row2 = new TableRow();
 
            Table table = new Table();
       
            var cell1 = new TableHeaderCell();
            row.TableSection = TableRowSection.TableHeader;
            cell1.Text = "Header";
            row.Cells.Add(cell1);
            var cell2 = new TableCell();
            cell2.Text = "Contents";
            row2.Cells.Add(cell2);
            table.Rows.Add(row);
            table.Rows.Add(row2);
            this.Controls.Add(table);
            
