    public static class GridViewExtensions
    {
        public static IEnumerable<GridViewRow> AsEnumerable(this GridView grid)
        {
            foreach (GridViewRow row in grid.Rows)
            {
                yield return row;
            }
        }
        public static bool IsEmpty(this GridView grid)
        {
            return !grid.AsEnumerable().Any(t => t.RowType == DataControlRowType.DataRow);
        }
    }
