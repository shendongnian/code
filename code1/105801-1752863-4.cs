     public static string ActionLinkWithList( this HtmlHelper helper, string text, string action, string controller, object routeData, object htmlAttributes )
     {
         var urlHelper = new UrlHelper( helper.ViewContext.RequestContext );
         string href = urlHelper.Action( action, controller );
         if (routeData != null)
         {
             RouteValueDictionary rv = new RouteValueDictionary( routeData );
             List<string> urlParameters = new List<string>();
             foreach (var key in rv.Keys)
             {
                 object value = rv[key];
                 if (value is IEnumerable && !(value is string))
                 {
                     foreach (object val in (IEnumerable)value)
                     {
                         urlParameters.Add( string.Format( "{0}={1}", key, val ));
                     }
                 }
                 else
                 {
                     urlParameters.Add( string.Format( "{0}={1}", key, value ) );
                 }
             }
             string paramString = string.Join( "&", urlParameters.ToArray() ); // ToArray not needed in 4.0
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
