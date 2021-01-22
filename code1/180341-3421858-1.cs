    foreach (HtmlElement tag in webBrowser.Document.All)
    {
        tag.Id = String.Empty;
        switch (tag.TagName.ToUpper())
        {
            case "A":
            {
                tag.MouseUp += new HtmlElementEventHandler(link_MouseUp);
                break;
            }
        }
    }
    private void link_MouseUp(object sender, HtmlElementEventArgs e)
    {
        mshtml.HTMLAnchorElementClass a = (mshtml.HTMLAnchorElementClass)((HtmlElement)sender).DomElement;
        switch (e.MouseButtonsPressed)
        {
            case MouseButtons.Left:
            {
                // open new tab
                break;
            }
            case MouseButtons.Right:
            {
                // open context menu
                break;
            }
        }
    }
