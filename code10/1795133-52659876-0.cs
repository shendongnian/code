    str = queries
        .Tables[1]
        .AsEnumerable()
        .Select(dataRow =>
        {
            var query = new Query
            {
                CommandText = dataRow.Field<string>("CommandText"),
                DataSetName = dataRow.Field<string>("DataSetName")
            };
            
            switch (dataRow.Field<string>("DictVal"))
            {
                case "Key":
                    query.Key = dataRow.Field<int>("Fields");
                    break;
                case "Value":
                    query.Value = dataRow.Field<string>("DataField");
                    break;
            }
            return query;
        })
        .ToList();
