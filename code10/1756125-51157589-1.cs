    private Cell CreateNotesCell(IList<ProductAttribute> notes)
    {
    	// Create a notes cell
    	var notesCell = new Cell()
    		.SetBackgroundColor(RegularBackgroundColor)
    		.SetPadding(10)
    		.SetMargins(20, 10, 20, 20);
    
    	// Set the our custom renderer for the cell
    	notesCell.SetNextRenderer(new RoundCornerСellRenderer(notesCell));
    
    	// Create an inner table for the notes
    	var tableNotes = new Table(1)
    		.SetWidth(UnitValue.CreatePercentValue(100));
    
    	// Add a header of the inner table
    	tableNotes.AddHeaderCell(new TextCell("Примечание",
    		BoldFont, TitleForegroundColor, false));
    
    	// Fill the inner table
    	foreach(var note in notes)
    		tableNotes.AddCell(new TextCell($"{note.Name}: {string.Join(", ", note.Options)}", 
    			LightFont, RegularForegroundColor));
    
    	// Add the inner table to the parent cell
    	notesCell.Add(tableNotes);
    
    	return notesCell;
    }
    
    private Cell CreatePriceCell(decimal price)
    {
    	// Create a price cell
    	var priceCell = new Cell()
    		.SetBackgroundColor(RegularBackgroundColor)
    		.SetPadding(10)
    		.SetMargins(20, 20, 20, 10);
    
    	// Set the our custom renderer for the cell
    	priceCell.SetNextRenderer(new RoundCornerСellRenderer(priceCell));
    
    	// Create an inner table for the price
    	var tablePrice = new Table(1)
    		.SetWidth(UnitValue.CreatePercentValue(100));
    
    	// Add a header of the inner table
    	tablePrice.AddHeaderCell(new TextCell("Цена",
    		BoldFont, TitleForegroundColor, false, TextAlignment.RIGHT));
    
    	// Fill the inner table
    	tablePrice.AddCell(new TextCell(price.ToString(), 
    		LightFont, RegularForegroundColor, true, TextAlignment.RIGHT));
    
    	// Add the inner table to the parent cell
    	priceCell.Add(tablePrice);
    
    	return priceCell;
    }
