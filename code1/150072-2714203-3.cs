    static class Utils {
        public static IEnumerable<TRow> CurrentRows(IEnumerable<TRow> table) where TRow : DataRow {
            foreach(TRow row in table) {
                if (row.RowState != DataRowState.Deleted)
                    yield return row;
            }
        }
    }
    foreach (myDataTableRow row in Utils.CurrentRows(_dt))
    {
