        // If there are any errors for a named field, we add the css attribute.
        ModelState modelState;
        if (htmlHelper.ViewData.ModelState.TryGetValue(name, out modelState)) {
            if (modelState.Errors.Count > 0) {
                tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
            }
        }
        // The first newline is always trimmed when a TextArea is rendered, so we add an extra one
        // in case the value being rendered is something like "\r\nHello".
        // The attempted value receives precedence over the explicitly supplied value parameter.
        string attemptedValue = (string)htmlHelper.GetModelStateValue(name, typeof(string));
        tagBuilder.SetInnerText(Environment.NewLine + (attemptedValue ?? ((useViewData) ? htmlHelper.EvalString(name) : value)));
        return tagBuilder.ToString(TagRenderMode.Normal);
