    public static class InputExtensions
    {
        public static IDictionary<string, object> TurnObjectIntoDictionary(object data)
        {
            var attr = BindingFlags.Public | BindingFlags.Instance;
            var dict = new Dictionary<string, object>();
            if (data == null)
                return dict;
            foreach (var property in data.GetType().GetProperties(attr))
            {
                if (property.CanRead)
                {
                    dict.Add(property.Name, property.GetValue(data, null));
                }
            }
            return dict;
        }
        
        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool disabled)
        {
            IDictionary<string, object> values =  TurnObjectIntoDictionary(htmlAttributes);
            
            if (disabled)
                values.Add("disabled","true");
            
            return htmlHelper.TextBoxFor(expression, values);
        }
        public static MvcHtmlString TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool disabled)
        {
            IDictionary<string, object> values = TurnObjectIntoDictionary(htmlAttributes);
            if (disabled)
                values.Add("disabled", "true");
            return htmlHelper.TextAreaFor(expression, values);
        }
        public static MvcHtmlString CheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, object htmlAttributes, bool disabled)
        {
            IDictionary<string, object> values = TurnObjectIntoDictionary(htmlAttributes);
            if (disabled)
                values.Add("disabled", "true");
            return htmlHelper.CheckBoxFor(expression, values);
        }
    }
