    public void AssignSequences(string SequenceName, string PropertyName,
        IEnumerable<object> DomainObjects)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connectionstring))
        {
            conn.Open();
            using (NpgsqlTransaction trans = conn.BeginTransaction())
            {
                using (NpgsqlCommand id = new NpgsqlCommand(string.Format(
                    "select nextval('{0}')", SequenceName),
                    conn, trans))
                {
                    foreach (object o in DomainObjects)
                    {
                        PropertyInfo p = o.GetType().GetProperty(PropertyName);
                        p.SetValue(o, Convert.ToInt32(id.ExecuteScalar()));
                    }
                }
                trans.Commit();
            }
            conn.Close();
        }
    }
