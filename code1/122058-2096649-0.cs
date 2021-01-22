	for(int i=listBox1.Items.Count; i > -1; i--) {
	{
		if(listBox1.Items[i].Contains("OBJECT"))
		{
			listBox1.Items.RemoveAt(i);
		}
	}
