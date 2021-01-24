    private void Click_Submit(object sender, EventArgs e) {
        foreach (ListViewItem lvi in listView1.SelectedItems)
            listView1.Items.Remove(lvi);
        if (string.IsNullOrWhiteSpace(textBox1.Text))
            MessageBox.Show("Please enter a serial number!", "Input");
        else
            InserSerialNumber(textBox1.Text);
        textBox1.Text = string.Empty;
        textBox1.Focus();
        textBox1.SelectionStart = textBox1.Text.Length == 0 ? 0 : textBox1.Text.Length - 1;
        textBox1.SelectionLength = 0;
        LoadSerialNumbers();
    }
    private void InsertSerialNumber(string sn) {
        using (OleDbCommand odc = new OleDbCommand("INSER INTO SN_Incoming(SN) VALUES(@SN)", con) {
            odc.Parameters.AddWIthValue("@SN", sn);
            try {
                con.Open();
                odc.ExecuteNonQuery();
            } catch (Exception e) { MessageBox.Show(e.Message); }
        }
    }
    private void LoadSerialNumbers() {
        listView1.Items.Clear();
        DataTable dt = new DataTable();
        using (OleDbCommand odc = new OleDbCommand("SELECT * FROM SN_Incoming", con) {
            try {
                con.Open();
                using (OleDbDataAdapter oda = new OleDbDataAdapter(odc))
                    ida.Fill(dt);
            } catch (Exception e) { MessageBox.Show(e.Message); }
        }
        List<ListViewItem> items = new List<ListViewItem>();
        foreach (DataRow row in dt.Rows) {
            ListViewItem lvi = items.SingleOrDefault(s => s.Tag == row[1].ToString());
            if (lvi != null)
                continue;
            lvi = new ListViewItem(new string[] { row[0].ToString(), row[1].ToString(), row[2].ToString() });
            lvi.Tag = row[1].ToString();
            items.Add(lvi);
        }
        listView1.Items.AddRange(items.ToArray());
    }
