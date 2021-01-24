    public int Id;
    public string Content;
    public string Url
}
    string[] lines = richTextBox1.Text.Split(Environment.NewLine);
    List<Table> items = new List<Table>();
    int id = 1;
    for (int i=0;i < lines.Length; i++)
    {
          string[] tmp = lines[i].Split('|');
          foreach (string x in tmp[1].Split('.'))
              if(!x.Trim()=="")
                  items.Add(new Table{ Id = id++ , Content = x + ".", Url = tmp[2] }); 
    }
    
