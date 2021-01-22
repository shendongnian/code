    protected void Button1_Click(object sender, EventArgs e)
    {
        // update some controls in the UpdatePanel
        ...
        
        // add an iframe which will start the download at the bottom of the UpdatePanel
        var iframe = new HtmlGenericControl("iframe");
        iframe.Style["display"] = "none";
        iframe.Attributes["src"] = "http://...download url...";
        iframe.EnableViewState = false      // we only need the iframe for this one postback
        myUpdatePanel.ContentTemplateContainer.Controls.Add(iframe)
    }
