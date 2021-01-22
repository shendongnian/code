    using System.CodeDom;
    using System.Web.Compilation;
    using System.Web.UI;
    [ExpressionPrefix("Code")]
    public class CodeExpressionBuilder : ExpressionBuilder
    {
       public override CodeExpression GetCodeExpression(BoundPropertyEntry entry,
          object parsedData, ExpressionBuilderContext context)
       {
          return new CodeSnippetExpression(entry.Expression);
       }
    }
