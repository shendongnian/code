     OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //Prepare things
                using(OleDbConnection conn = new OleDbConnection(pathConn))
                {
                    conn.Open(); //Added this line
                    spreadSheetData = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    foreach (DataRow dr in spreadSheetData.Rows)
                    {
                          //Do staff
                    }
                }
            }
