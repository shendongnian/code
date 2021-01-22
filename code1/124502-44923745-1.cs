    public List<S> GetData<S>(string query, Func<IDataRecord, S> selector)
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.Connection.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        var items = new List<S>();
                        while (r.Read())
                            items.Add(selector(r));
                        return items;
                    }
                }
            }
