    public static class GridExtensions
    {
        public static IEnumerable<DependencyObject> GetChildren(this Grid grid, int row, int column)
        {
            int count = VisualTreeHelper.GetChildrenCount(grid);
            for (int i = 0; i < count; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(grid, i);
                int r = Grid.GetRow(child);
                int c = Grid.GetColumn(child);
                if (r == row && c == column)
                {
                    yield return child;
                }
            }
        }
    }
