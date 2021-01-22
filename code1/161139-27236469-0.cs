     public static MvcHtmlString StrongTypeBinder(this HtmlHelper htmlhelper, Expression<Func<object, string>> SomeLambda)
        {
            var body = SomeLambda.Body;
            var propertyName = ((PropertyInfo)((MemberExpression)body).Member).Name;
            HtmlString = @"
                <input type='text' name='@Id' id='@Id'/>
                ";
            HtmlString = HtmlString.Replace("@Id", propertyName);
            var finalstring = new MvcHtmlString(HtmlString);
            return finalstring;
        }
