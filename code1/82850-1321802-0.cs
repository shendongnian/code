    public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog1.Multiselect)
                    {
                        long total = 0;
                        foreach (string s in openFileDialog1.FileNames)
                            total += new FileInfo(s).Length;
                        MessageBox.Show(total.ToString());
    
                          
                    }
                    else
                    {
                        MessageBox.Show(new FileInfo(openFileDialog1.FileName).Length.ToString());
                    }
                    
    
                }
            }
