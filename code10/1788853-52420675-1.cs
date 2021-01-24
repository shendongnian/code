    foreach (ListViewItem item in listView1.Items)
       foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
          if (subitem.Text.Equals(filterbox.Text, StringComparison.OrdinalIgnoreCase))
          {
             item.BackColor = SystemColors.Highlight;
             item.ForeColor = SystemColors.HighlightText;
             break;
          }
