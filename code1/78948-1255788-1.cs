    ListViewItem item = new ListViewItem();
    item.text = "Column A";
    item.SubItems.Add("");
    item.SubItems.Add("Column C");
    
    m_listView.Items.Add(item);
    
    m_listView.Items[0].SubItems[2].Text  = "change text of column C";
    m_listView.Items[0].SubItems[1].Text  = "change text of column B";
    m_listView.Items[0].SubItems[0].Text  = "change text of column A";
