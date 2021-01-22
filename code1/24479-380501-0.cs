    List<string> removals = new List<string>();
    foreach (string s in listBox1.Items)
    {
        MessageBox.Show(s);
        //do stuff with (s);
        removals.Add(s);
    }
    foreach (string s in removals)
    {
        listBox1.Items.Remove(s);
    }
