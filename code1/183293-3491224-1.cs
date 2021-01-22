    public static string Images(this HtmlHelper htmlHelper, string id)
    {
        var urlHelper = ((Controller)htmlHelper.ViewContext.Controller).Url; 
        var photoUrl = urlHelper.Action("GetPhoto", "Clinical", new { imageId = id });
        var img = new TagBuilder("img");
        img.MergeAttribute("src", photoUrl);
        return img.ToString();
    }
