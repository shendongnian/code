    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Compilation;
    using System.Web.UI;
    namespace TelerikCodeBlock
    {
        [ExpressionPrefix("Code")]
        public class CodeExpressionBuilder : ExpressionBuilder
        {
            public override CodeExpression GetCodeExpression(BoundPropertyEntry entry,
               object parsedData, ExpressionBuilderContext context)
            {
                return new CodeSnippetExpression(entry.Expression);
            }
        }
    }
