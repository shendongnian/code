    DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string databasePath = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                string dbname = openFileDialog1.FileName.Split('.')[0];
                //SqlConnection dataBaseConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename={0};Integrated Security=True;Connect Timeout=30;User Instance=True");
                string connection = @"Data Source=(LocalDb)\v11.0;AttachDbFilename=" + databasePath + ";Initial Catalog=" + dbname + ";Integrated Security=True";
                SqlConnection dataBaseConnection = new SqlConnection(connection);
                try
                {
                    dataBaseConnection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
