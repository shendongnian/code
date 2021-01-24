        if (grid.SortedColumn?.Index == e.ColumnIndex)
        {
            var sortIcon = grid.SortOrder == SortOrder.Ascending ? "▲":"▼";
    
            //Just for example I rendered a character, you can draw an image.
            TextRenderer.DrawText(e.Graphics, sortIcon,
                e.CellStyle.Font, e.CellBounds, sortIconColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
