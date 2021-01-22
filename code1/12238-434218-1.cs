    void SetDefaultButton(Panel panel, IButtonControl button)
    {
        string uniqueId = ((Control)button).UniqueID;
        string panelIdPrefix = panel.NamingContainer.UniqueID + Page.IdSeparator;
        if (uniqueId.StartsWith(panelIdPrefix))
        {
            uniqueId = uniqueId.Substring(panelIdPrefix.Length);
        }
        panel.DefaultButton = uniqueId;
    }
