    private void addLineToListView(String col1Text, String col2Text, String col3Text)
        {
            ListViewItem lvItem;
            if ((lvItem = this.listView1.Items.Add(col1Text)) != null)
            {
                lvItem.SubItems.Add(col2Text);
                lvItem.SubItems.Add(col3Text);
            }
        }
