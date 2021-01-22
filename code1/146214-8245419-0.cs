     StringBuilder sb;
     if (listView.Items.Count > 0)
     {
         // the actual data
         foreach (ListViewItem lvi in listView.Items)
         {
             sb = new StringBuilder();
             foreach (ListViewItem.ListViewSubItem listViewSubItem in lvi.SubItems)
             {
                 sb.Append(string.Format("{0}\t", listViewSubItem.Text));
             }
             sw.WriteLine(sb.ToString());
         }
         sw.WriteLine();
     }
