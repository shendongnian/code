    protected override void OnCellPainting(
    DataGridViewCellPaintingEventArgs args)
    {
       base.OnCellPainting(args);
       args.AdvancedBorderStyle.Bottom =
       DataGridViewAdvancedCellBorderStyle.None;
       // Ignore column and row headers and first row
       if (args.RowIndex < 1 || args.ColumnIndex < 0)
          return;
       if (IsRepeatedCellValue(args.RowIndex, args.ColumnIndex))
       {
           args.AdvancedBorderStyle.Top =
           DataGridViewAdvancedCellBorderStyle.None;
       }
       else
       {
           args.AdvancedBorderStyle.Top = AdvancedCellBorderStyle.Top;
       }
    }
