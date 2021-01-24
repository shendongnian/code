    protected void RepeaterCommand(object source, RepeaterCommandEventArgs e)
    {
        Image img = e.Item.FindControl("Image") as Image;
        Session.Remove(img.ImageUrl);
    }
