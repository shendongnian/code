    private void button2_Click(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedRows.Count != 0 && listBox1.SelectedIndex != -1)
        {            
            using(var con = new SqlConnection(connectionString))
            {
                var trn = con.BeginTransaction();
                var sqlGetStudentId = "select studentID from student where studentName = @studentName";   
                using(var cmd = new SqlCommand(sqlGetStudentId, conn))
                {
                    cmd.Parameters.Add("@studentName", SqlDbType.VarChar).Value = listBox1.SelectedItem.ToString();
                    try
                    {
                        con.Open();
                        var studentId = cmd.ExecuteScalar()?.ToString();
                        if(!string.IsNullOrEmpty(studentId))
                        {
                            // Note: You must first check if there are books left to borrow!
                            cmd.CommandText = "update Book set quantity=quantity-1 where bookID = @BookId";
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@BookId", SqlDbType.VarChar).Value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "insert into Borrow (/* Alwasy specify columns list! */) values (@IAmGuessingBookId, @StudentId, GETDATE(), NULL)";
                            cmd.Parameters.Clear();
                            cmd.Parameters.Add("@IAmGuessingBookId", SqlDbType.VarChar).Value = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                            cmd.Parameters.Add("@StudentId", SqlDbType.VarChar).Value = studentId;
                            cmd.ExecuteNonQuery();
                            
                            trn.Commit();
                        }
                    }
                    catch(Exception ex)
                    {
                        // Do something with the exception!
                        // show an error description to the client,
                        // log for future analisys
                        trn.Rollback();
                    }
                }
            }
            
        }
    }
