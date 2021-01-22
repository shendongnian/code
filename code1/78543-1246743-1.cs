    static IEnumerable<DataRow> DoSearch(DataTable table, RegEx r, string fieldName) {
        return table.AsEnumerble()
                    .Where(row => r.IsMatch(row.Field<string>(fieldName).Replace(" ", ""))
                    .OrderBy(row => row.Field<string>(fieldName));
    }
    var table = passwordData.Tables["PasswordValue"];
    var results = DoSearch(table, r, "Key")
        .Union(DoSearch(table, r, "Username")
        .Union(DoSearch(table, r, "Other");
