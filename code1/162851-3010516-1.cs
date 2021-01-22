    <% if (Model.SomeCondition) { 
       Response.Write("<div><ul>");
       Response.Write (Html.ActionLink(Model.TemplateLinkName, "DownloadTemplate", "ExternalData", new ArgsDownloadTemplate { Path = Model.TemplateLocation, FileName = Model.TemplateFileNameForDownload }, new{}));
       Response.Write("</ul></div>");
    } %>
