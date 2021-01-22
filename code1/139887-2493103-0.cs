    private void myDataGrid_MouseDown(object sender, 
    System.Windows.Forms.MouseEventArgs e)
    {
       DataGrid myGrid = (DataGrid) sender;
       System.Windows.Forms.DataGrid.HitTestInfo hti;
       hti = myGrid.HitTest(e.X, e.Y);
       string message = "You clicked ";
    
       switch (hti.Type) 
       {
          case System.Windows.Forms.DataGrid.HitTestType.None :
             message += "the background.";
             break;
          case System.Windows.Forms.DataGrid.HitTestType.Cell :
             message += "cell at row " + hti.Row + ", col " + hti.Column;
             break;
          case System.Windows.Forms.DataGrid.HitTestType.ColumnHeader :
             message += "the column header for column " + hti.Column;
             break;
          case System.Windows.Forms.DataGrid.HitTestType.RowHeader :
             message += "the row header for row " + hti.Row;
             break;
          case System.Windows.Forms.DataGrid.HitTestType.ColumnResize :
             message += "the column resizer for column " + hti.Column;
             break;
          case System.Windows.Forms.DataGrid.HitTestType.RowResize :
             message += "the row resizer for row " + hti.Row;
             break;
          case System.Windows.Forms.DataGrid.HitTestType.Caption :
             message += "the caption";
             break;
          case System.Windows.Forms.DataGrid.HitTestType.ParentRows :
             message += "the parent row";
             break;
          }
    
          Console.WriteLine(message);
    }
