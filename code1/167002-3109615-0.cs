    public static string Delimit(string name) {
        return "[" + name.Replace("]", "]]") + "]";
    }
    // Construct the command...
    sc.CommandType = CommandType.Text;
    sc.CommandText = "delete from " + Delimit(tableName);
    sc.ExecuteNonQuery();
