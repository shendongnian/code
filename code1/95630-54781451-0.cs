    private void lv_TavComEmpty_ColumnClick(object sender, ColumnClickEventArgs e)
            {
                ListView lv = (ListView)sender;
                
                //propriety SortOrder make me some problem on graphic layout
                //i use this tag to set last order
                if (lv.Tag == null || (int)lv.Tag > 0)
                //if (lv.Sorting == SortOrder.Ascending)
                {
                    ListViewItem[] tmp = lv.Items.Cast<ListViewItem>().OrderBy(t => t.SubItems[e.Column].Text).ToArray();
                    lv.Items.Clear();
                    lv.Items.AddRange(tmp);
    
                    lv.Tag = -1;
                    //lv.Sorting = SortOrder.Descending;
                }
                else
                {
                    ListViewItem[] tmp = lv.Items.Cast<ListViewItem>().OrderByDescending(t => t.SubItems[e.Column].Text).ToArray();
                    lv.Items.Clear();
                    lv.Items.AddRange(tmp);
    
                    lv.Tag = +1;
                    //lv.Sorting = SortOrder.Ascending;
                }
            }
