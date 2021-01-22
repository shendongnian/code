    public static void RemoveNullColumnFromDataTable(DataTable dt)
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (dt.Rows[i][1] == DBNull.Value)
                        dt.Rows[i].Delete();
                }
                dt.AcceptChanges();
            }
