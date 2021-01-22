    ListView lv = new ListView();
    using (FileStream fs = new FileStream(@"c:\whatever.txt", FileMode.Open))
    {
        StreamReader reader = new StreamReader(fs);
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine(); // e.g. "BOB|SMITH|JR."
            string[] coldata = line.Split('|');
            ListViewItem item = new ListViewItem(coldata);
            lv.Items.Add(item);
        }
    }
