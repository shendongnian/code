    private void exportDGVToCSV(string filename)
        {
            if(dataGridView1.Columns.Count != 0) {
                StringBuilder myString = new StringBuilder();
                
                if (File.Exists(FilePath + "file"))
                {
                    File.Delete(FilePath + "file");
                }
                StreamWriter sw = new StreamWriter(filename, true);
                // loop through each row of our DataGridView
               
                foreach(DataGridViewRow row in dataGridView1.Rows) {
                    foreach(DataGridViewCell cell in row.Cells) {               
                        myString.Append(cell.Value + ",");
                        myString.Append("\r\n");
                                 
                    }
                }
                sw.WriteLine(myString.ToString());
                sw.Close();
                GC.Collect();
            }
        }
