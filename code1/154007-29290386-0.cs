    // Return the input string with all parsed HTML links having the "target" attribute set to specified value
    // Links without a target attribute will have the attribute added, existing attributes values are updated
    public static string SetHtmlLinkTargetAttribute(this string inputHtmlString, string target)
    {
        var htmlContent = new HtmlDocument();
        htmlContent.LoadHtml(inputHtmlString);
    
        // Parse HTML content for links
        var links = htmlContent.DocumentNode.SelectNodes("//a");
        foreach (var link in links)
        {
            link.SetAttributeValue("target", target);
        }
    
        return htmlContent.DocumentNode.OuterHtml;
    }
