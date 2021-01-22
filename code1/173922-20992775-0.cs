         namespace your.namespace
        {
        public class CustomBuilder : ExpressionBuilder
        {
            public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
            {
                Type type1 = entry.DeclaringType;
                PropertyDescriptor descriptor1 = TypeDescriptor.GetProperties(type1)[entry.PropertyInfo.Name];
                CodeExpression[] expressionArray1 = new CodeExpression[1];
                expressionArray1[0] = new CodePrimitiveExpression(entry.Expression.Trim());
                
                String temp = entry.Expression;
                return new CodeCastExpression(descriptor1.PropertyType, new CodeMethodInvokeExpression(new
               CodeTypeReferenceExpression(base.GetType()), "GenerateLink", expressionArray1));
            }
            public static  String GenerateLink(String link)
            {
                return ConfigurationManager.AppSettings["MediaPath"] + link + "?ver=" + ConfigurationManager.AppSettings["MediaCode"];
            }
        }
        }
