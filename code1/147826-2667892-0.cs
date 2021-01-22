    string data;
    using(System.IO.StreamReader reader = new System.IO.StreamReader("filepath"))
    {
        data = reader.ReadToEnd();
    }
    
    string[] lines = data.Split(Environment.NewLine);
    
    for(int index = 0; index < lines.Length; index += 7)
    {
        ListViewItem item = new ListViewItem();
        for(int innerIndex = 0; innerIndex < 7; innerIndex++)
        {
            item.SubItems.Add(lines[index + innerIndex]);
        }
    
        listView1.Items.Add(item);
    }
