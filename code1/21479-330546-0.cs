    public delegate string Indexer<T>(T obj);
    public static string concatenate<T>(IEnumerable<T> collection, Indexer<T> indexer, char separator)
    {
        StringBuilder sb = new StringBuilder();
        foreach (T t in collection) sb.Append(indexer(t)).Append(separator);
        return sb.Remove(sb.Length - 1, 1).ToString();
    }
    // example 1: simple int list
    string getAllInts(IEnumerable<int> listOfInts)
    {
        return concatenate<int>(listOfInts, Convert.ToString, ',');
    }
    // example 2: DataTable.Rows
    string getTitle(DataRow row) { return row["title"]; }
    string getAllTitles(DataTable table)
    {
        return concatenate<DataRow>(table.Rows, getTitle, '\n');
    }
