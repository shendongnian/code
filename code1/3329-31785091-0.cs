    public static bool ExecuteExternalScript(string filePath)
    {
        using (StreamReader file = new StreamReader(filePath))
        using (SqlConnection conn = new SqlConnection(dbConnStr))
        {
            StringBuilder sql = new StringBuilder();
            string line;
            while ((line = file.ReadLine()) != null)
            {
                // replace GO with semi-colon
                if (line == "GO")
                    sql.Append(";");
                // remove inline comments
                else if (line.IndexOf("--") > -1)
                    sql.AppendFormat(" {0} ", line.Split(new string[] { "--" }, StringSplitOptions.None)[0]);
                // just the line as it is
                else
                    sql.AppendFormat(" {0} ", line);
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
            cmd.ExecuteNonQuery();
        }
        return true;
    }
