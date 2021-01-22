    private void InsertLinkButton(string text, string id, UpdatePanel updateSummary,
                                  EventHandler clickHandler)
    {
        LinkButton link = new LinkButton();
        link.Text = text;
        link.Click += clickhandler;
        ...
    }
