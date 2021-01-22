    public static void CreateFromDataset(DataSet set, SqlCeConnection conn)
        {
            conn.Open();
            SqlCeCommand cmd;
            foreach (DataTable table in set.Tables)
            {
                string createSql = copyDB.GetCreateTableStatement(table);
                Console.WriteLine(createSql);
                cmd = new SqlCeCommand(createSql, conn);
                Console.WriteLine(cmd.ExecuteNonQuery());
            }
            conn.Close();
        }
    }
