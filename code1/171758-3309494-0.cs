	int tableColumns = 3;
	    Table aTable = new Table(tableColumns);
	    int row = 1;
	    int col = 0;
	                   foreach (Barcode s in codeslist)
                {
		                    // Create new barcode
                    Image imageCode128 = GetImageCode128(s);
                    // Create a new cell to host the barcode image
                    Cell cell = new Cell();
                    cell.Add(imageCode128);
                    aTable.AddCell(cell,row,col);
                    if (col == tableColumns-1)
                    {
                        col = 0;
                        row ++;
                    }
		    else col++;
		                    }
                // Add the completed table to the Document and close it.
                document.Add(aTable);
                document.Close();
