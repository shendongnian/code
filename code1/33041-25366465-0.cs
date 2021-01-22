        /// <summary>
        /// Returns html string with new lines as br tags
        /// </summary>
        public static MvcHtmlString ConvertNewLinesToBr<TModel>(this HtmlHelper<TModel> html, string text)
        {
            return  new MvcHtmlString(html.Encode(text).Replace(Environment.NewLine, "<br />"));
        }
