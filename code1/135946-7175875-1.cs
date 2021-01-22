       private void updateList(Dictionary<string, string> dict, ListView list)
        {
            #region Sort
            list.Items.Clear();
 
            string[] arrays = dict.Keys.ToArray();
            int num = 0;
            while (num <= dict.Count)
            {
                if (num == dict.Count)
                {
                    break;
                }
                ListViewItem lvi;
                ListViewItem.ListViewSubItem lvsi;
    
                lvi = new ListViewItem();
                lvi.Text = dict[arrays[num]].ToString();
                lvi.ImageIndex = 0;
                lvi.Tag = dict[arrays[num]].ToString();
                lvsi = new ListViewItem.ListViewSubItem();
                lvsi.Text = arrays[num];
                lvi.SubItems.Add(lvsi);
                list.Items.Add(lvi);
                list.EndUpdate();
                num++;
            }
            #endregion
        }
