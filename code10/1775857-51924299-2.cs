	private void Button1_Click(object sender, RoutedEventArgs e)
	{
		foreach(string strUrl in Urllines)
			dataGrid1.Items.Add(new { URL = strUrl});
	}
