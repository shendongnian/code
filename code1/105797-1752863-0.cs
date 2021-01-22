     public static string ActionLinkWithList( this HtmlHelper helper, string text, string action, string controller, object routeData, object htmlAttributes )
     {
         var urlHelper = new UrlHelper( helper.ViewContext.RequestContext );
         string href = urlHelper.Action( action, controller );
         if (routeData != null)
         {
             RouteValueDictionary rv = new RouteValueDictionary( routeData );
             List<string> parameters = new List<string>();
             foreach (var key in rv.Keys)
             {
                 object value = params[key];
                 if (value is IEnumerable)
                 {
                     foreach (string val in (IEnumerable)value)
                     {
                         parameters.Add( string.Format( "{0}={1}", key, val );
                     }
                 }
                 else
                 {
                     parameters.Add( string.Format( "{0}={1}", key, value ) );
                 }
             }
             string paramString = string.Join( "&", parameters.ToArray() );
             if (!string.IsNullOrEmpty( paramString ))
             {
                href += "?" + paramString;
             }
         }
         TagBuilder builder = new TagBuilder( "a" );
         builder.Attributes.Add("href",href);
         builder.MergeAttributes( new RouteValueDictionary( htmlAttributes ) );
         builder.SetInnerText( text );
         return builder.ToString( TagRenderMode.Normal );
    }
