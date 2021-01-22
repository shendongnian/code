    public void ListItemSorter(object sender, ColumnClickEventArgs e)
        {
            ListView list = (ListView)sender;
            int total = list.Items.Count;
            list.BeginUpdate();
            ListViewItem[] items = new ListViewItem[total];
            for (int i = 0; i < total; i++)
            {
                int count = list.Items.Count;
                int minIdx = 0;
                for (int j = 1; j < count; j++)
                    if (list.Items[j].SubItems[e.Column].Text.CompareTo(list.Items[minIdx].SubItems[e.Column].Text) < 0)
                        minIdx = j;
                items[i] = list.Items[minIdx];
                list.Items.RemoveAt(minIdx);
            }
            list.Items.AddRange(items);
            list.EndUpdate();
        }
