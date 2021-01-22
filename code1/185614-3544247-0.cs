		private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if(listBox1.SelectedIndex != -1)
			{
				var rect = listBox1.GetItemRectangle(listBox1.SelectedIndex);
				if(rect.Contains(e.Location))
				{
					// process item data here
				}
			}
		}
