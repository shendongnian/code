    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
                {            
                    var fileNameAndPath = filedisplaylabel.Text; 
            if (string.IsNullOrEmpty((fileNameAndPath)))
            {
                OpenFileDialog openfiledialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filedisplaylabel.Text = Path.GetFullPath(openFileDialog1.FileName); 
                    fileNameAndPath = filedisplaylabel.Text;
                }
            }                        
                try
                {
                    using (FileStream fstream = new FileStream(fileNameAndPath,
                        FileMode.Open,
                            FileAccess.Write))
                    {
                        using (StreamWriter write = new StreamWriter(fstream))
                        {
                            foreach (var item in WebListBox.Items)
                                write.WriteLine(item.ToString());
                            write.Close();
                        }
                        fstream.Close();
                    }
                }
                catch (DirectoryNotFoundException ex)
                {
                    MessageBox.Show(ex.Message, "File not found error");
                }                                                                                 
        }
