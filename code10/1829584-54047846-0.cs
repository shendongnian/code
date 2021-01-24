        public static bool DoesRecordExist(DataTable dt, List<KeyValuePair<string, string>> keyValuePairs)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                bool exists = dt.AsEnumerable().Where(r =>
                {
                    foreach (var kvp in keyValuePairs)
                    {
                        if (string.Equals(SafeTrim(r[kvp.Key]), kvp.Value, StringComparison.CurrentCultureIgnoreCase))
                        {
                            return false;
                        }
                    }
                    return true;
                }).Any();
                return exists;
            }
            else
            {
                return false;
            }
        }
