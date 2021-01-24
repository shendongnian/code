        DataTable MyTableWhenExport(DataTable dt)
        {
            // insert argument checking here
            foreach (var dataRow in dt.AsEnumerable())
            {
                var value = dataRow.Field<string>("MyColumn");
                if (string.IsNullOrWhitespace(value))
                {
                    // handle accordingly
                }
                else
                {
                    value = value.Substring(0, value.LastIndexOf('=') + 1);
                    dataRow.SetField("MyColumn", value);
                }
            }
            return dt;
        }
