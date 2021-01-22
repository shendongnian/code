    XElement element = null;
    if (txtPr3_Chain.Text != "")
    {
        element = new XElement("Property_Info",
                                new XAttribute("Chain", txtPr3_Chain.Text),
                                new XElement("City", txtPr3_City.Text),
                                new XElement("AdRating", AdRating3.CurrentRating.ToString()),
                                new XElement("YourRating", YourRating3.CurrentRating.ToString()),
                                new XElement("Comment", txtPr3_Comments.Text));
    }
