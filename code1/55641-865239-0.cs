    DataTable prefs = new DataTable();
    IEnumerable<DataColumn> cols = (from u in users
                                    from p in u.UserPreferences
                                    select p.Name)
                                   .Distinct()
                                   .Select(n => new DataColumn(n));
    prefs.Columns.Add("FirstName");
    prefs.Columns.Add("LastName");
    prefs.Columns.AddRange(cols.ToArray());
    foreach (User user in users)
    {
        DataRow row = prefs.NewRow();
        row["FirstName"] = user.FirstName;
        row["LastName"] = user.LastName;
        foreach (UserPreference pref in user.UserPreferences)
        {
            row[pref.Name] = pref.UserValue;
        }
        prefs.Rows.Add(row);
    }
