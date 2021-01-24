        if (grid.SortedColumn?.Index == e.ColumnIndex)
        {
            var sortIcon = grid.SortOrder == SortOrder.Ascending ?
                VisualStyleElement.Header.SortArrow.SortedUp : 
                VisualStyleElement.Header.SortArrow.SortedDown;
            var renderer = new VisualStyleRenderer(sortIcon);
            var size = renderer.GetPartSize(e.Graphics, ThemeSizeType.Draw);
            renderer.DrawBackground(e.Graphics,
                new Rectangle(e.CellBounds.Right - size.Width,
                e.CellBounds.Top, size.Width, e.CellBounds.Height));
        }
