    // Create a new HtmlTable object.
		HtmlTable table1 = new HtmlTable();
		// Set the table's formatting-related properties.
		table1.Border = 1;
		table1.CellPadding = 3;
		table1.CellSpacing = 3;
		table1.BorderColor = "red";
		// Start adding content to the table.
		HtmlTableRow row;
		HtmlTableCell cell;
		for (int i = 1; i <= 5; i++)
		{
			// Create a new row and set its background color.
			row = new HtmlTableRow();
			row.BgColor = (i % 2 == 0 ? "lightyellow" : "lightcyan");
			for (int j = 1; j <= 4; j++)
			{
				// Create a cell and set its text.
				cell = new HtmlTableCell();
				cell.InnerHtml = "Row: " + i.ToString() +
				  "<br>Cell: " + j.ToString();
				// Add the cell to the current row.
				row.Cells.Add(cell);
			}
			// Add the row to the table.
			table1.Rows.Add(row);
		}
		// Add the table to the page.
		this.Controls.Add(table1);
