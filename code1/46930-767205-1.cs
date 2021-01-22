    FillList(IList<ListItem> listItems)
    {
    if (this.InvokeRequired)
        {
            this.Invoke((MethodInvoker)delegate
            {
                foreach (ListItem listItem in listItems)
                {
                    ListViewItem item = new ListViewItem(listItem .Name);
                    item.SubItems.Add(listItem.Empty.ToString());
                    item.SubItems.Add(listItem.Population.ToString());
                    item.SubItems.Add(listItem.Max.ToString());
                    item.SubItems.Add(listItem.Checked ? "No" : "Yes");
                    listView1.Items.Add(item);
                }
            }
        }
    }
