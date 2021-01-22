	List<string> items = new List<string>() { "aaa", "bbb", "ccc", "ddd", "eee" };
	int colSize = (int)Math.Ceiling(items.Count / 3.0);
	HtmlGenericControl ul = null;
	for (int i = 0; i < items.Count; i++)
	{
		if (i % colSize == 0)
		{
			ul = new HtmlGenericControl("ul");
			Page.Form.Controls.Add(ul);
		}
		
		HtmlGenericControl li = new HtmlGenericControl("li");
		li.InnerText = items[i];
		ul.Controls.Add(li);
	}
