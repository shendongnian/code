    HtmlGenericControl li;
    
    for (int x = 3; x <= 10; x++)
    {
        li = new HtmlGenericControl("li");
        li.Attributes.Add("class", "myItemClass");
        li.InnerText = "Item " + x;
    
        myList.Controls.Add(li);
    }
