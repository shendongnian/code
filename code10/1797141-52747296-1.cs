        public static MvcHtmlString PartialFor<TModel, TProperty>(this HtmlHelper<TModel> html, 
                Expression<Func<TModel, TProperty>> expression, string partialViewName)
        {
            var compiled = expression.Compile();
            var result = compiled.Invoke(html.ViewData.Model);
            return html.Partial(partialViewName, result);
        }
