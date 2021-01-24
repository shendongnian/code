    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
	{
		TextBox tb = sender as TextBox;
		XElement parentNode = tb.DataContext as XElement;
		string nodeName = tb.Tag as string;
		XElement node = parentNode.Element(nodeName);
		if (node == null)
		{
			node = new XElement(nodeName);
			parentNode.Add(node);
		}
		node.Value = tb.Text
    }
