        private void btn1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            SqlConnection con = new SqlConnection(@"Server=.\SQLEXPRESS; Database=Student; Integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter("SELECT name,id FROM info WHERE id LIKE '" + txtbox1.Text + "%'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            listView1.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                listView1.Items.Add(item);
            }
	}
