     // Returns the first item that satisfies the condition or null if none does.
            ListViewItem found = items.FirstOrDefault(i => i.SubItems[1].Text.Equals("Amount5").Equals("Amount5"));
            if(found != null) {
                MessageBox.Show(found.SubItems[0].Text.ToString());
            }
            else {
                MessageBox.Show("Not Found!");
            }
