    foreach (YourType item in grid.DataSource)
    {
       foreach (DataGridColumn column in grid.Columns)
       {
          FrameworkElement cellContent = column.GetCellContent(item);
    
          // Now, determine the type of cell content and act accordingly.
          TextBlock block = cellContent as TextBlock;
          if (block != null)
          {
             // Report text value...
          }
    
          // ...etc...
         
       }
    }
