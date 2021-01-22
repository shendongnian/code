    //create a nullable intermediate variable
    System.DateTime? dtCellValue = resultsGrid.CurrentRow.Cells["DateOfBirth"].Value as System.DateTime?;
    
    //if this cell has been set to String.Emtpy the cast will fail
    //so ensure the intermediate variable isn't null
    if ( dtCellValue.HasValue && dtCellValue == System.DateTime.MinValue )
    //set cell value appropriately
