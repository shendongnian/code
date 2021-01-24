        private void mySreamReader()
        {
            try
            {
                dataGridView1.Rows.Clear();
                StreamReader streamReader = new StreamReader (@"C:\Users\lee\Lees App File\LeesHistoryFile.txt");
                dataGridView1.AllowUserToAddRows = false;
                string text = "";
                for (text = streamReader.ReadLine(); text != null; text = streamReader.ReadLine())
                {
                  
                        string[] array = text.Split(new char[] { '|' });
                        dataGridView1.Rows.Add(array);
                    
                }
                streamReader.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error" + err.Message);
            }
        }
