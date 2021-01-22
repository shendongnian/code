                    public static MvcHtmlString ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string prefix, Expression<Func<TModel, TProperty>> expression)
        {
            return ValidationMessageFor(htmlHelper, prefix, expression, null, new RouteValueDictionary());
        }
        public static MvcHtmlString ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string prefix, Expression<Func<TModel, TProperty>> expression, string validationMessage)
        {
            return ValidationMessageFor(htmlHelper, prefix, expression, validationMessage, new RouteValueDictionary());
        }
        public static MvcHtmlString ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string prefix, Expression<Func<TModel, TProperty>> expression, string validationMessage, object htmlAttributes)
        {
            return ValidationMessageFor(htmlHelper, prefix, expression, validationMessage, new RouteValueDictionary(htmlAttributes));
        }
        public static MvcHtmlString ValidationMessageFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string prefix, Expression<Func<TModel, TProperty>> expression, string validationMessage, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.ValidationMessage(String.Format("{0}.{1}", prefix, ExpressionHelper.GetExpressionText(expression)),
                validationMessage,
                htmlAttributes);
        }
        public static MvcHtmlString HiddenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string prefix, Expression<Func<TModel, TProperty>> expression)
        {
            return HiddenFor(htmlHelper, prefix, expression, (IDictionary<string, object>)null);
        }
        public static MvcHtmlString HiddenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string prefix, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return HiddenFor(htmlHelper, prefix, expression, new RouteValueDictionary(htmlAttributes));
        }
        public static MvcHtmlString HiddenFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string prefix, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.Hidden(String.Format("{0}.{1}", prefix, ExpressionHelper.GetExpressionText(expression)),
                ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model,
                htmlAttributes);
            /*return HiddenHelper(htmlHelper,
                                ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model,
                                false,
                                ExpressionHelper.GetExpressionText(expression),
                                htmlAttributes);*/
        }
        public static MvcHtmlString TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string prefix, Expression<Func<TModel, TProperty>> expression)
        {
            return TextAreaFor(htmlHelper, prefix, expression, (IDictionary<string, object>)null);
        }
        public static MvcHtmlString TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string prefix, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return TextAreaFor(htmlHelper, prefix, expression, new RouteValueDictionary(htmlAttributes));
        }
        public static MvcHtmlString TextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string prefix, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            string value;
            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            if (modelMetadata.Model != null)
                value = modelMetadata.Model.ToString();
            else
                value = String.Empty;
            return htmlHelper.TextArea(String.Format("{0}.{1}", prefix, ExpressionHelper.GetExpressionText(expression)),
                value,
                htmlAttributes);
        }
        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string prefix, Expression<Func<TModel, TProperty>> expression)
        {
            return TextBoxFor(htmlHelper, prefix, expression, (IDictionary<string, object>)null);
        }
        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string prefix, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return TextBoxFor(htmlHelper, prefix, expression, new RouteValueDictionary(htmlAttributes));
        }
        public static MvcHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string prefix, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            return htmlHelper.TextBox(String.Format("{0}.{1}", prefix, ExpressionHelper.GetExpressionText(expression)),
                ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).Model,
                htmlAttributes);
        }
