            try
            {
                OpenFileDialog dlg_im = new OpenFileDialog();
                dlg_im.Filter = "Excel File|*.xls;*.xlsx;*.xlsm";
                //dlg_im.Filter = "Excel File|*.xlsx";
                if (dlg_im.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1.Rows.Clear();
                    textBox1.Text = dlg_im.FileName;
                    string name = "Sheet1";
                    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                    OleDbConnection Con = new OleDbConnection(constr);
                    OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [Sheet1$B13:B33]", Con);
                    Con.Open();
                    OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dataGridView1.DataSource = data;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.Columns[0].Width = 320;
                    dataGridView1.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            MessageBox.Show("Done");
