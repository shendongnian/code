     protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           List<ListItem> list = new List<ListItem>();
           list.Add(ListBox1.SelectedItem);
           string testValue = list[0].Value; // this is how you access a listitem in the List
        }
