                row.Cells["colProjection"].Value = string.Join("\t", feature.Select(f => Math.Abs(f / 30).ToString("N3")));
                TextWriter writer = new StreamWriter(@"C:\Users\LENOVO\Desktop\OKE.txt");
                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    writer.Write(row.Cells["colProjection"].Value + "\t"); 
                }
                writer.WriteLine("");
                writer.Close();
