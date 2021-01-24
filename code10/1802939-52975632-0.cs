    string[] arrNames = // new[] {"ID", "STATUS", "TYPE"};
    var datalist = new List<IDictionary<string, string>>();
    for (var i = 0; i < dt.Rows.Count; ++i)
        datalist.Add(
            arrNames
                .Select(key =>
                    new
                    {
                        key,
                        value = Convert.ToString(dt.Rows[i][key])
                    }
                )
                .ToDictionary(x => x.key, x => x.value)
        );
