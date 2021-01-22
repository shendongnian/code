            private void export2File(ListView lv, string splitter)
            {
                string filename = "";
                SaveFileDialog sfd = new SaveFileDialog();
    
                sfd.Title = "SaveFileDialog Export2File";
                sfd.Filter = "Text File (.txt) | *.txt";
    
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    filename = sfd.FileName.ToString();
                    if (filename != "")
                    {
                        using (StreamWriter sw = new StreamWriter(filename))
                        {
                            foreach (ListViewItem item in lv.Items)
                            {
                                sw.WriteLine("{0}{1}{2}", item.SubItems[0].Text, splitter, item.SubItems[1].Text);
                            }
                            sw.Close();
                        }
                    }
                }
            }
