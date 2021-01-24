     using (connection)
            {
                string sql =
                    "Delete from YourTable t join @yourTypeTable i on t.id = i.Id:";
                SqlCommand deleteCommand = new SqlCommand(sql, connection);
                SqlParameter tvpParam = deleteCommand.Parameters.AddWithValue("@yourTypeTable", yourIdList);
                tvpParam.SqlDbType = SqlDbType.Structured;
                tvpParam.TypeName = "dbo.yourTypeTable";
                deleteCommand.ExecuteNonQuery();
            }
