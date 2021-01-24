    private void ChangeClass(object sender, EventArgs e)
    {
        HtmlButton myHtmlButton = sender as HtmlButton;
    
        if (myHtmlButton.Attributes["class"] == "test")
        {
            myHtmlButton.Attributes["class"] = "test1";
        }
        else
        {
            myHtmlButton.Attributes["class"] = "test";
        }
    }
