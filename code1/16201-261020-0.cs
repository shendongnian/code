    HtmlGenericControl list = new HtmlGenericControl("ul");
    for (int i = 0; i < 10; i++)
    {
    	HtmlGenericControl listItem = new HtmlGenericControl("li");
    	Label textLabel = new Label();
    	textLabel.Text = String.Format("Label {0}", i);
    	listItem.Controls.Add(textLabel);
    	list.Controls.Add(listItem);
    }
    PlaceHolder1.Controls.Add(list);
