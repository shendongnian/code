    foreach (var luafile in luafiles)
    {
        FileObject f = new FileObject();
        f.FileName = Path.GetFileName(luafile.ToString());
        f.Content = File.ReadAllText(luafile.ToString());                            
        listBox1.Items.Add(f);
    }
    
    foreach (var txtfile in txtfiles)
    {
        FileObject f = new FileObject();
        f.FileName = Path.GetFileName(txtfile.ToString());
        f.Content = File.ReadAllText(txtfile.ToString());                            
        listBox1.Items.Add(f);
    }
