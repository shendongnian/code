    public static IHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> html, Expression<Func<TModel, TEnum>> expression)
    {            
        var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
     
        var enumType = Nullable.GetUnderlyingType(metadata.ModelType) ?? metadata.ModelType;
     
        var enumValues = Enum.GetValues(enumType).Cast<object>();
     
        var items = from enumValue in enumValues                        
                    select new SelectListItem
                    {
                        Text = GetResourceValueForEnumValue(enumValue),
                        Value = ((int)enumValue).ToString(),
                        Selected = enumValue.Equals(metadata.Model)
                    };
     
     
        return html.DropDownListFor(expression, items, string.Empty, null);
    }
     
    private static string GetResourceValueForEnumValue<TEnum>(TEnum enumValue)
    {
        var key = string.Format("{0}_{1}", enumValue.GetType().Name, enumValue);
     
        return Enums.ResourceManager.GetString(key) ?? enumValue.ToString();
    }
