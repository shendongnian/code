    TextWriter txt = new StreamWriter("IP.txt");
    foreach (var item in listBox1.Items)
    {
        txt.WriteLine(Environment.NewLine + item.ToString());
        txt.Close();
    }
    
    listBox1.Items.Clear();
    TextReader reader = new StreamReader("IP.txt");
    
    listBox1.Items.Add(Environment.NewLine + reader.ReadToEnd());
    reader.Close();
