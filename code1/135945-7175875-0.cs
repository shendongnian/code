    private void removeDupBtn_Click(object sender, EventArgs e)
        {   
         
            Dictionary<string, string> dict = new Dictionary<string, string>();
            
            int num = 0;
            while (num <= listView1.Items.Count)
            {
                if (num == listView1.Items.Count)
                {
                    break;
                }
                if (dict.ContainsKey(listView1.Items[num].SubItems[1].Text).Equals(false))
                {
                    dict.Add(listView1.Items[num].SubItems[1].Text, ListView1.Items[num].SubItems[0].Text);
                }     
                
                num++;
            }
            updateList(dict, listView1);
                       
        }
