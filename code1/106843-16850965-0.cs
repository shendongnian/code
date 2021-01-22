    private static void Render(IList<ListData> list, IDataReader reader)
            {
                while (reader.Read())
                {
                    listData.DownUrl = (reader.GetSchemaTable().Columns["DownUrl"] != null) ? Convert.ToString(reader["DownUrl"]) : null;
                    //没有这一列时，让其等于null
                    list.Add(listData);
                }
                reader.Close();
            }
