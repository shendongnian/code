    private void listView1_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
                {      
                    StringBuilder widths = new StringBuilder();
                    widths.Clear();
               
                    for (int i = 0; i < listView1.Columns.Count; i++)
                    {
                        int columnWide = listView1.Columns[i].Width;
                        string columnName = listView1.Columns[i].Text;
                        widths.Append(columnName + ":" + columnWide.ToString() + "#");
                    }
                    string line= widths.ToString(); 
                }
