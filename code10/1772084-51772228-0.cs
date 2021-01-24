      var wb = new XLWorkbook(northwinddataXlsx);
      var ws = wb.Worksheet("Data");
    
      // Look for the first row used
      var firstRowUsed = ws.FirstRowUsed();
    
      // Narrow down the row so that it only includes the used part
      var categoryRow = firstRowUsed.RowUsed();
    
      // Move to the next row (it now has the titles)
      categoryRow = categoryRow.RowBelow();
    
      // Get all categories
      while (!categoryRow.Cell(coCategoryId).IsEmpty())
      {
        String categoryName = categoryRow.Cell(coCategoryName).GetString();
        categories.Add(categoryName);
    
        categoryRow = categoryRow.RowBelow();
      }
