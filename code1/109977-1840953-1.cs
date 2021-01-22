    if (checkBox3.Checked)
    {
        string[] lines = File.ReadAllLines(@"C:\NCR.txt");
    
        foreach (string line in lines)
        {
            string[] files = Directory.GetFiles(textBox2.Text, line + "*.txt");
            foreach (string file in files)
            {
                 FileInfo file_info = new FileInfo(file);
                 File.Copy(file, @"C:\InPrep\" + textBox1.Text + "\\text\\" + file_info.Name);
            }
        }
    }
