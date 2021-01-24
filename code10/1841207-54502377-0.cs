    private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                for (int i = 0; i < dgvAtt.Rows.Count - 1; i++)
                {
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    string Query = "INSERT INTO Person (idPerson, fullnamePerson) VALUES (" + dgvAtt.Rows[i].Cells[0].Value.ToString() + ",'" + dgvAtt.Rows[i].Cells[1].Value.ToString() + "')";
                    cmd.CommandText = Query;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Updated! please check the report", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
