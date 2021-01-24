    Style cellStyle = new Style (typeof (DataGridCell));
    cellStyle.Setters.Add (new Setter (DataGridCell.FontFamilyProperty, new FontFamily ("Consolas")));
    //cellStyle.Setters.Add (new Setter (DataGridCell.HorizontalAlignmentProperty, HorizontalAlignment.Center));
    //cellStyle.Setters.Add (new Setter (DataGridCell.VerticalAlignmentProperty, VerticalAlignment.Center));
    cellStyle.Setters.Add (new Setter (TextBlock.TextAlignmentProperty, TextAlignment.Center));
    cellStyle.Setters.Add (new Setter (DataGridCell.ForegroundProperty, Brushes.MediumSeaGreen));
