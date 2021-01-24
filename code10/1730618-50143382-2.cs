        ListViewItem found = null;
            foreach(ListViewItem item in Listview1.Items) {
                if(item.array[1].Equals("Value 5")) {
                    // If a match was found break the loop.
                    found = item;
                    break;
                }
      
            }
            if (found != null) {
                MessageBox.Show(found.array[0]);
            }
            else {
                MessageBox.Show("Not Found!");
            }
 
