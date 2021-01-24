          ListViewItem found = null;
            foreach (ListViewItem item in listView1.Items) {
                if (item.SubItems[1].Text.Equals("Amount5")) {
                    // If a match was found break the loop.
                    found = item;
                    break;
                }
            }
            if (found != null) {
                MessageBox.Show(found.SubItems[0].Text.ToString());
            }
            else {
                MessageBox.Show("Not Found!");
            }
 
