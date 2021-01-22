    var link = new HtmlGenericControl("link");
    link.Attributes.Add("rel", "shortcut icon");
    link.Attributes.Add("src", ResolveUrl("~/Resources/Pictures/Shared/Misc/favicon.ico"));
    link.Attributes.Add("type", "image/x-icon");
    
    Header.Controls.Add(link);
