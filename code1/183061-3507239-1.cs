    using System.CodeDom;
    using System.CodeDom.Compiler;
    using System.Reflection;
    using System.Text;
    using System.IO;
    using Microsoft.CSharp;
    using Microsoft.VisualBasic;
    
    namespace CodeDom
    {
        class Program
        {       
            static CodeDomProvider provider;
    
            static void Main(string[] args)
            {
                Program shell = new Program();
                provider = new VBCodeProvider();
                CodePrimitiveExpression left = new CodePrimitiveExpression("throw new Error(\"Unhandled Error in Silverlight Application\")");
                CodeVariableReferenceExpression middle = new CodeVariableReferenceExpression("errorMsg");
                CodePrimitiveExpression right = new CodePrimitiveExpression("\");");
    
                CodeTypeReferenceExpression targetObject = new CodeTypeReferenceExpression("System.Windows.Browser.HtmlPage.Window");
                string methodName = "Eval";
    
                string vbStatement =  shell.ConcatStatement(left, middle, right, targetObject, methodName);
    
                provider = new CSharpCodeProvider();
    
                string csStatement = shell.ConcatStatement(left, middle, right, targetObject, methodName);
    
                Console.WriteLine(vbStatement);
                Console.WriteLine(csStatement);
                Console.ReadLine();
    
            }
    
            public string ConcatStatement(CodePrimitiveExpression left, CodeVariableReferenceExpression middle, CodePrimitiveExpression right, CodeTypeReferenceExpression targetObject, string methodName)
            {
                CodeExpression evalMessage = new CodeExpression();
                evalMessage = ConcatString(left, middle, right);
    
                CodeMethodInvokeExpression eval = new CodeMethodInvokeExpression(targetObject, methodName, evalMessage);
                CodeExpressionStatement evalStatement = new CodeExpressionStatement(eval);
                using (TextWriter tx = new StringWriter())
                {
                    provider.GenerateCodeFromStatement(evalStatement, tx, new CodeGeneratorOptions());
                    return tx.ToString();
                }
            }
    
            private CodeExpression ConcatString(CodeExpression left, CodeExpression middle, CodeExpression right) {
                return new CodeSnippetExpression(CodeToString(left) + " + " + CodeToString(middle) + " + " + CodeToString(right));
            }
    
            private string CodeToString(CodeExpression expr) {
                using (TextWriter tx = new StringWriter()) {
                    provider.GenerateCodeFromExpression(expr,tx, new CodeGeneratorOptions());
                    return tx.ToString();
                }
            }
        }
    }
