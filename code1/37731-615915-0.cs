    [System.Web.Compilation.ExpressionPrefix("Delegate")]
        public class DelegateExpressionBuilder : ExpressionBuilder
        {
            public override CodeExpression GetCodeExpression(BoundPropertyEntry entry, object parsedData, ExpressionBuilderContext context)
            {           
               
             return new CodeDelegateCreateExpression(new CodeTypeReference("System.EventHandler"), null, entry.Expression);
            }
        }
