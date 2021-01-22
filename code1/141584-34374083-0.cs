    namespace IdeaR.Web.Compilation
    {
    [ExpressionPrefix("CdnUrl")]
    public class CdnUrlExpressionBuilder : ExpressionBuilder
    {
        public static object GetCdnUrl(string expression, Type target, string entry)
        {
            var retvalue = expression;
            var productionUri = new Uri("http://www.myproductionurl.com",
                UriKind.Absolute);
            var currentUri = HttpContext.Current.Request.Url;
            var cdnUrl = "http://cdn.mycdn.com";
 
            // If this is a production website URL
            if (currentUri.Scheme == productionUri.Scheme &&
                currentUri.Host == productionUri.Host)
                retvalue = cdnUrl + expression;
 
            return retvalue;
        }
 
        public override CodeExpression GetCodeExpression(BoundPropertyEntry entry,
            object parsedData, ExpressionBuilderContext context)
        {
            var componentType = entry.DeclaringType;
            var expressionArray = new CodeExpression[3]
            {
                new CodePrimitiveExpression(entry.Expression.Trim()),
                new CodeTypeOfExpression(componentType),
                new CodePrimitiveExpression(entry.Name)
            };
 
            var descriptor = TypeDescriptor.GetProperties(componentType)
                [entry.PropertyInfo.Name];
            return new CodeCastExpression(descriptor.PropertyType,
                new CodeMethodInvokeExpression(
                    new CodeTypeReferenceExpression(GetType()),
                    "GetCdnUrl", expressionArray));
        }       
    }
    }
