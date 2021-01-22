    public static string ActionLinkSpan( this HtmlHelper helper, string linkText, string actionName, string controllerName, object htmlAttributes )
    {
        TagBuilder spanBuilder = new TagBuilder( "span" );
        spanBuilder.InnerHtml = linkText;
        return BuildNestedAnchor( spanBuilder.ToString(), string.Format( "/{0}/{1}", controllerName, actionName ), htmlAttributes );
    }
    private static string BuildNestedAnchor( string innerHtml, string url, object htmlAttributes )
    {
        TagBuilder anchorBuilder = new TagBuilder( "a" );
        anchorBuilder.Attributes.Add( "href", url );
        anchorBuilder.MergeAttributes( new ParameterDictionary( htmlAttributes ) );
        anchorBuilder.InnerHtml = innerHtml;
        return anchorBuilder.ToString();
    }
