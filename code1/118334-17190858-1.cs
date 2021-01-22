            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string selectedempid = dataGridView1.SelectedRows[0].Cells["Deptno"].Value.ToString();
                {
                    SqlCommand cmd = new SqlCommand("delete from Test_dept where Deptno=" + selectedempid, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("deleted");
                }
            }
