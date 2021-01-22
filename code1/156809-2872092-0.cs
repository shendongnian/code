	bool found = false;
	foreach (ListViewItem item in listView1.Items)
	{
		 if (item.Text.Equals("Coke"))
		 {
			  int amt = int.Parse(item.SubItems[1].Text);
			  amt++;
			  item.SubItems[1].Text = amt.ToString();
			  found = true;
		 }
	}
	if (!found)
	{
		 ListViewItem item = listView1.Items.Add("Coke");
		 item.SubItems.Add("1");
	}
