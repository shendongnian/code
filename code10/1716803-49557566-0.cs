    string folder = @"C:/Aatrox";    
    
    private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
         var fileName = (string)ListBox1.SelectedItem;       
         textEditorControl1.Text = File.ReadAllText(Paht.Combine(folder, fileName));
    }
    
    private void FlatButton3_Click(object sender, EventArgs e)
    {
            ListBox1.Items.Clear();
    
            string[] txtfiles = Directory.GetFiles(folder, "*.txt");
            string[] luafiles = Directory.GetFiles(folder, "*.lua");
    
            foreach (var item in txtfiles)
            {
                ListBox1.Items.Add(Path.GetFileName(item));
            }
    
            foreach (var item in luafiles)
            {
               ListBox1.Items.Add(Path.GetFileName(item));
            }
    }
