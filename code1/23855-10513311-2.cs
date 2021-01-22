    Hashtable ht = new Hashtable();
        Hashtable CreateColumnHash(SqlDataReader dr)
        {
            ht = new Hashtable();
            for (int i = 0; i < dr.FieldCount; i++)
            {
                ht.Add(dr.GetName(i), dr.GetName(i));
            }
            return ht;
        }
        bool ValidateColumn(string ColumnName)
        {
            return ht.Contains(ColumnName);
        }
