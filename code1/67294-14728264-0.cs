    private void txtRead_Click(object sender, EventArgs e)
            {
               // var filename = @"d:\shiptest.txt";
    
                openFileDialog1.InitialDirectory = "d:\\";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (openFileDialog1.FileName != "")
                    {
                        var reader = ReadAsLines(openFileDialog1.FileName);
    
                        var data = new DataTable();
    
                        //this assume the first record is filled with the column names
                        var headers = reader.First().Split(',');
                        foreach (var header in headers)
                        {
                            data.Columns.Add(header);
                        }
    
                        var records = reader.Skip(1);
                        foreach (var record in records)
                        {
                            data.Rows.Add(record.Split(','));
                        }
    
                        dgList.DataSource = data;
                    }
                }
            }
    
            static IEnumerable<string> ReadAsLines(string filename)
            {
                using (StreamReader reader = new StreamReader(filename))
                    while (!reader.EndOfStream)
                        yield return reader.ReadLine();
            }
