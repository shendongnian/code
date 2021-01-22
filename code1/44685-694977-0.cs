     private void Form1_Load(object sender, EventArgs e)
            {
                
                List<string> str = GetListOfFiles(@"D:\Music\Bee Gees - Their Greatest Hits - The Record");
                listBox1.DataSource = str;
                listBox1.DisplayMember = "str";
         
        
            }
    
            private List<string> GetListOfFiles(string Folder)
            {
                DirectoryInfo dir = new DirectoryInfo(Folder);
                FileInfo[] files = dir.GetFiles("*.mp3", SearchOption.AllDirectories);
                List<string> str = new List<string>();
                foreach (FileInfo file in files)
                {                             
                    str.Add(file.FullName);                   
    
                }
                return str;
            }
    
            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                string strSelected = listBox1.SelectedValue.ToString();
                MessageBox.Show(strSelected); //Just demo, you can add code that have WMP played this file here 
            }
