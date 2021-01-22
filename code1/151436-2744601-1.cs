    public IEnumerable<T> GetSequenceFromTable<T>(DataTable table, string colName)
    {
        foreach (DataRow row in table)
        {
            yield return (T)(row["colName"]);
        }
    }
