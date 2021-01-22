        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create dataset to hold csv data:
            DataSet ds = new DataSet();
            ds.Tables.Add();
            ds.Tables[0].Columns.Add();
            ds.Tables[0].Columns.Add();
            ds.Tables[0].Columns.Add();
            ds.Tables[0].Columns.Add();
            ds.Tables[0].Columns.Add();
            ds.Tables[0].Columns.Add();
            string[] row = new string[1];
            // read csv data from clipboard
            IDataObject t = Clipboard.GetDataObject();
            System.IO.StreamReader sr =
                    new System.IO.StreamReader((System.IO.MemoryStream)t.GetData("csv"));
            // assign csv data to dataset      
            while (!(sr.Peek() == -1))
            {
                row[0] = sr.ReadLine();
                ds.Tables[0].Rows.Add(row);
            }
            // set data source
            dataGridView1.DataSource = ds.Tables[0];
        }
   
