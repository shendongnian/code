            TableRow headerRow = new TableHeaderRow();
            TableRow row2 = new TableRow();
            TableRow row3 = new TableFooterRow();
            Table table = new Table();
       
            var cell1 = new TableCell();
            headerRow.TableSection = TableRowSection.TableHeader;
            cell1.Text = "Header";
            headerRow.Cells.Add(cell1);
            var cell2 = new TableCell();
            cell2.Text = "Contents";
            row2.Cells.Add(cell2);
            var cell3 = new TableCell();
            cell3.Text = "Footer";
            row3.Cells.Add(cell3);
            row3.TableSection = TableRowSection.TableFooter;
            
            table.Rows.Add(headerRow);
            table.Rows.Add(row2);
            table.Rows.Add(row3);
            this.Controls.Add(table);
