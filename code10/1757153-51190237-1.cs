        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            string sqlQuery = string.Format("SELECT DocumentContent,DBName FROM myDatabase WHERE ID={0};", id);
            SqlDataAdapter myAdapter1 = new SqlDataAdapter(sqlQuery, myConnection);
            DataTable dt = new DataTable();
            myAdapter1.Fill(dt);
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
           
            foreach (DataRow row in dt.Rows)
            {
                byte[] byteArray = (byte[])row["DocumentContent"];
                string name = (string)row["DBName"];
                saveFileDialog1.FileName = name;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                     if ((myStream = saveFileDialog1.OpenFile()) != null)
                     {
                          myStream.Write(byteArray, 0, byteArray.Length);
                          myStream.Close();
                     }
                 }
                //File.WriteAllBytes("Path\\" + name, byteArray);
            }
        }
