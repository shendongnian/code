    public static bool IsRequired<T, V>(this Expression<Func<T, V>> expression, HtmlHelper<T> htmlHelper)
        {
            var modelMetadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
            FieldValidationMetadata fieldMetadata = ApplyFieldValidationMetadata(htmlHelper, modelMetadata, modelName);
            foreach (var item in fieldMetadata.ValidationRules)
            {
                if (item.ValidationType == "required")
                    return true;
            }
            
            return false;
        }
    
        private static FieldValidationMetadata ApplyFieldValidationMetadata(HtmlHelper htmlHelper, ModelMetadata modelMetadata, string modelName)
        {
            FormContext formContext = htmlHelper.ViewContext.FormContext;
            FieldValidationMetadata fieldMetadata = formContext.GetValidationMetadataForField(modelName, true /* createIfNotFound */);
    
            // write rules to context object
            IEnumerable<ModelValidator> validators = ModelValidatorProviders.Providers.GetValidators(modelMetadata, htmlHelper.ViewContext);
            foreach (ModelClientValidationRule rule in validators.SelectMany(v => v.GetClientValidationRules()))
            {
                fieldMetadata.ValidationRules.Add(rule);
            }
    
            return fieldMetadata;
        }
