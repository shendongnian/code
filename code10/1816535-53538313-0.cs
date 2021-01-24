    public int Id;
    public string Content;
    public string Url
}
    string[] lines = richTextBox1.Text.Split(Environment.NewLine);
    Table[] items = new Table[lines.Length];
    for (int i=0;i < lines.Length; i++)
    {
          string[] tmp = lines[i].Split('|');
          items.Add(new Table{ Id = tmp[0], Content = tmp[1], Url = tmp[2] }); 
    }
    
