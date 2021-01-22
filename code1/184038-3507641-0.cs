    using System.IO;
    FolderBrowserDialog fbd = new FolderBrowserDialog();
    if (fbd.ShowDialog() == DialogResult.OK)
    {
        listView1.Items.Clear();
        listView1.View = View.LargeIcon;
        ListViewItem lvi;
        string[] files = Directory.GetFiles(fbd.SelectedPath);
        foreach (string file in files)
        {
            lvi = new ListViewItem(file);
            listView1.Items.Add(lvi);
        }
    }
