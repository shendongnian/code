    public Form1()
            {
                InitializeComponent();
            }
    
            private void browse_Click(object sender, EventArgs e)
            {
                openFileDialog1.Title = "Add File";
                openFileDialog1.Filter = "All Files (*.*)|*.*";
                openFileDialog1.FileName = "";
                openFileDialog1.Multiselect = true;
                openFileDialog1.ShowDialog();
            }
    
            private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
            {
                string[] sFilePath;
                sFilePath = openFileDialog1.FileNames;
                if (sFilePath.Length == 0)
                {
                    return;
                }
                checkedListBox1.Items.AddRange(sFilePath);
    
            }
    
            private void upload_Click(object sender, EventArgs e)
            {
                SqlConnection thisConnection = new
                      SqlConnection(@"YOUR CONNECTION STRING");
                thisConnection.Open();
                try
                {
    
                    SqlCommand mySqlCommand = thisConnection.CreateCommand();
    
    
                    foreach (var item in checkedListBox1.SelectedItems)
                    {
    
                        string filepath = item.ToString();
                        if (!File.Exists(filepath))
                        {
                            continue;
                        }
                        string filename = new FileInfo(filepath).Name;
                        byte[] rawData = File.ReadAllBytes(filepath);
    
                        mySqlCommand.CommandText = "INSERT INTO Files ( [fname],[file]) VALUES (@fname,@file)";
                        mySqlCommand.Parameters.Add("@fname", SqlDbType.NVarChar);
                        mySqlCommand.Parameters.Add("@file", SqlDbType.VarBinary);
                        mySqlCommand.Parameters["@fname"].Value = filename;
                        mySqlCommand.Parameters["@file"].Value = rawData;
    
                        mySqlCommand.ExecuteNonQuery();
                    }
                    thisConnection.Close();
                }
                catch
                {
                    thisConnection.Close();
                }
                checkedListBox1.Items.Clear();
    
                UpdateDropDown();
            }
    
            private void UpdateDropDown()
            {
    
                comboBox1.Items.Clear();
                SqlConnection thisConnection = new SqlConnection(@"YOUR CONNECTION STRING");
                thisConnection.Open();
    
                string str = "SELECT id, fname FROM [Files]";
                SqlCommand cmd = new SqlCommand(str, thisConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "uploadedfile");
    
                foreach (DataRow row in ds.Tables["uploadedfile"].Rows)
                {
                    comboBox1.Items.Add(new { id = row[0], value = row[1] });
                }
                thisConnection.Close();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "value";
                comboBox1.Update();
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                int selectedid = 2;
                if (selectedid < 0)
                { return; }
    
    
                SaveFileDialog savefileDialog1 = new SaveFileDialog();
                savefileDialog1.SupportMultiDottedExtensions = false;
                savefileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                savefileDialog1.Title = "Save file as...";
    
                DialogResult result = savefileDialog1.ShowDialog();
    
                if (result != DialogResult.OK)
                {
                    return;
                }
    
                string filename = savefileDialog1.FileName;
    
                SqlConnection thisConnection = new SqlConnection(@"YOUR CONNECTION STRING");
                thisConnection.Open();
    
                string str = "SELECT [file], fname FROM [Files] where id =" + selectedid;
                SqlCommand cmd = new SqlCommand(str, thisConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "uploadedfile");
    
                if (ds.Tables["uploadedfile"].Rows.Count > 0)
                {
                    byte[] bb = (byte[])ds.Tables["uploadedfile"].Rows[0]["file"];
                    Save(filename, bb);
                }
    
                thisConnection.Close();
    
    
            }
            private void Save(string file, byte[] data)
            {
                // save file 
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                UpdateDropDown();
        }
