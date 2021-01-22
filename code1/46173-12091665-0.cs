    grid.CellStyle = newCellStyle();
    public static Style newCellStyle()
    {
        //And here is the C# code to achieve the above
        System.Windows.Style style = new Style(typeof(DataGridCell));
        style.Setters.Add(new System.Windows.Setter
        {
            Property = Control.HorizontalAlignmentProperty,
            Value = HorizontalAlignment.Center
        });
        return style;
    }
