     using (var con = new SqlConnection(ConnectionString)) {
            int newID;
            var cmd = "insert into dtperson1 (name,age)values(@val1,@val2);SELECT CAST(scope_identity() AS int)";
            using (var insertCommand = new SqlCommand(cmd, con)) {
                insertCommand.Parameters.AddWithValue("@val1", dataGridView1.Rows[i].Cells[0].Value);
       insertCommand.Parameters.AddWithValue("@val2", dataGridView1.Rows[i].Cells[1].Value);
                con.Open();
                newID = (int)insertCommand.ExecuteScalar();
            }
        }
