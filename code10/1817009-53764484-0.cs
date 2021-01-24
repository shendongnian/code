    	// Save file dialogue XML file.
            if (saveFileDialogXml.ShowDialog() == DialogResult.OK)
            {
               //try block to catch exception and handle it.
                try
                {
                   //Changing Data Table name to stock.
                    string Stock = ((DataTable)Datagridview1.DataSource).TableName;
                }
                //Catching the exception and handling it.
                catch (Exception)
                {
                    string es = "Please Open The File Before Saving it";
                    string title = "Error";
                    MessageBox.Show(es, title);
                    
                    
                }
 	// instatiate new DataTable.
                DataTable dt = new DataTable
                {
                    TableName = "Stock"
                };
                for (int i = 0; i < Datagridview1.Columns.Count; i++)
                {
                    //if (dataGridView1.Columns[i].Visible) // Add's only Visible columns.
                    //{
                    string headerText = Datagridview1.Columns[i].HeaderText;
                    headerText = Regex.Replace(headerText, "[-/, ]", "_");
                    DataColumn column = new DataColumn(headerText);
                    dt.Columns.Add(column);
                    //}
                }
                foreach (DataGridViewRow DataGVRow in Datagridview1.Rows)
                {
                    DataRow dataRow = dt.NewRow();
                    // Add's only the columns that I need
                    dataRow[0] = DataGVRow.Cells["Item Code"].Value;
                    dataRow[1] = DataGVRow.Cells["Item Description"].Value;
                    dataRow[2] = DataGVRow.Cells["Current Count"].Value;
                    dataRow[3] = DataGVRow.Cells["On Order"].Value;
                    dt.Rows.Add(dataRow); //dt.Columns.Add();
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
               //Finally the save part:
                XmlTextWriter xmlSave = new XmlTextWriter(saveFileDialogXml.FileName, Encoding.UTF8)
                {
                    Formatting = Formatting.Indented
                };
                ds.DataSetName = "Data";
                ds.WriteXml(xmlSave);
                xmlSave.Close();
