    HtmlGenericControl ulControl = new HtmlGenericControl("ul");
    pnlItems.Controls.Add(ulControl);
    foreach (object myThing in myItems)
    {
        HtmlGenericControl itemControl = new HtmlGenericControl("li");
        itemControl.InnerHtml = myThing.GetMarkup();
        ulControl.Controls.Add(itemControl);
    }
