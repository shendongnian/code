		ListView.SelectedListViewItemCollection breakfast = 
			this.ListView1.SelectedItems;
		
		double price = 0.0;
		foreach ( ListViewItem item in breakfast )
		{
			price += Double.Parse(item.SubItems[1].Text);
		}
		// Output the price to TextBox1.
		TextBox1.Text = price.ToString();
	}
