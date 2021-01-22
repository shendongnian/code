    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString RadioButtonAndLabelFor<TModel, TProperty>(this HtmlHelper<TModel> self, Expression<Func<TModel, TProperty>> expression, bool value, string labelText)
        {
            // Retrieve the qualified model identifier
            string name = ExpressionHelper.GetExpressionText(expression);
            string fullName = self.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            // Generate the base ID
            TagBuilder tagBuilder = new TagBuilder("input");
            tagBuilder.GenerateId(fullName);
            string idAttr = tagBuilder.Attributes["id"];
            // Create an ID specific to the boolean direction
            idAttr = String.Format("{0}_{1}", idAttr, value);
            // Create the individual HTML elements, using the generated ID
            MvcHtmlString radioButton = self.RadioButtonFor(expression, value, new { id = idAttr });
            MvcHtmlString label = self.Label(idAttr, labelText);
            return new MvcHtmlString(radioButton.ToHtmlString() + label.ToHtmlString());
        }
    }
