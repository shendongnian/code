        public void RemoveDependencies(int versionID, int[] deps)
        {
            if (versionID <= 0)
                throw new ArgumentException();
            if (deps == null)
                throw new ArgumentNullException();
            if (deps.Length <= 0)
                throw new ArgumentException();
            SqlCommand cmd = new SqlCommand();
            string query = "DELETE FROM Dependencies WHERE version_id = @VersionId AND dep_version_id IN (";
            int n = deps.Length;
            string key;
            for (int i = 0; i < n; i++)
            {
                if (deps[i] <= 0)
                    throw new ArgumentException();
                key = String.Format("@dep{0}", i);
                query += key;
                cmd.Parameters.AddWithValue(key, deps[i]);
                if (i < n - 1)
                {
                     query += ", ";
                }
            }
            query += ")";
            cmd.Parameters.AddWithValue("@VersionId", versionID);
            cmd.CommandText = query;
            using (SqlConnection con = GetSqlConnection())
            {
                con.Open();
                cmd.Connection = con;
                if (cmd.ExecuteNonQuery() <= 0)
                {
                    throw new ArgumentException("No rows affected! Illegal id.");
                }
            }
        }
