    String[] file_names = File.ReadAllLines(@"C;\file.txt");
    HashSet<string> allFiles = new HashSet<string>();
    string[] files = Directory.GetFiles(@"I:\pax\", file_name + ".txt", SearchOption.AllDirectories);
    foreach (string file in files)
    {
        allFiles.Add(file);
    }
    foreach(string file_name in file_names)
    {
        String file = allFiles.FirstOrDefault(f => f == file_name);
        if (file != null)
        {
            System.IO.File.Copy(file, @"C:\" + textBox1.Text + @"\N\O\" + file_name + ".txt");
        }
    }
