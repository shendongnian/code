    public static IHtmlContent ToHtmlContent(this SelectListItem item) {
        var option = new TagBuilder("option");
        option.Attributes.Add("value", item.Value);
        if(item.Selected) {
            option.Attributes.Add("selected", "selected");
        }
        option.InnerHtml.Append(item.Text);
        return option;
    }
