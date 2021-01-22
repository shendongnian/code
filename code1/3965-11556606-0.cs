    #region Extension methods
    public static class ExtensionMethods
    {
        public static bool IsEmpty(this DataSet dataSet)
        {
            return dataSet == null || dataSet.Tables.Count == 0 || !dataSet.Tables.Cast<DataTable>().Any(i => i.Rows.Count > 0);
        }
    }
    #endregion
