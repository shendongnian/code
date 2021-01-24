    List<string> items = new List<string>();
    for (int i = 0; i < comboBox1.Items.Count; i++)
    {
        items.Add(comboBox1.Items[i].ToString().ToLower());
    }
    
    var files = Directory
            .EnumerateFiles(sourceDIR.Text, "*.*", SearchOption.AllDirectories)
            .Where(file => items.Any(item => file.ToLower().EndsWith(item)));
