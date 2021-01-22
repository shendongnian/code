    public static DataTable ReadCsv(string path)
    {
        DataTable result = new DataTable("SomeData");
        using (TextFieldParser parser = new TextFieldParser(path))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            bool isFirstRow = true;
            //IList<string> headers = new List<string>();
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                if (isFirstRow)
                {
                    foreach (string field in fields)
                    {
                        result.Columns.Add(new DataColumn(field, typeof(string)));
                    }
                    isFirstRow = false;
                }
                else
                {
                    int i = 0;
                    DataRow row = result.NewRow();
                    foreach (string field in fields)
                    {
                        row[i++] = field;
                    }
                    result.Rows.Add(row);
                }
            }
        }
        return result;
    }
