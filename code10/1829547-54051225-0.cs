    public static class Extensions
    {
        public static bool DoesRecordExist(this DataTable dt, Dictionary<string, string> KeysAndValues)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                var rows = dt.AsEnumerable();
                foreach (var key in KeysAndValues.Keys)
                {
                    rows = rows.Where(row => string.Equals(row[key], KeysAndValues[key], StringComparison.CurrentCultureIgnoreCase));
                }
                return rows.Any();
            }
            else
            {
                return false;
            }
        }
    }
