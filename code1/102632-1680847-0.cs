            System.Collections.SortedList asd = new SortedList();
            foreach (ListItem ll in ListBox1.Items)
            {
                asd.Add(ll.Text, ll.Value);
            }
            ListBox1.Items.Clear();
                        
            foreach (String key in asd.Keys)
            {
                ListBox1.Items.Add(new ListItem(key, asd[key].ToString()));
            }
