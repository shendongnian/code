using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace CodeScanner
{
  class StringsCollector : CSharpSyntaxWalker
  {
    public List<string> _strings = new List<string>();
    
    public override void VisitLiteralExpression(LiteralExpressionSyntax node)
    {
      if (node.IsKind(SyntaxKind.StringLiteralExpression))
      {
        // StringLiteralToken stringLiteralToken = node.Token;
        // Console.WriteLine(node.Token.Value);
        _strings.Add((string) node.Token.Value);
      }
        
    }
  }
  class Program
  {
    const string programText =
      @"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
 
namespace TopLevel
{
    using Microsoft;
    using System.ComponentModel;
 
    namespace Child1
    {
        using Microsoft.Win32;
        using System.Runtime.InteropServices;
 
        class Foo { }
    }
 
    namespace Child2
    {
        using System.CodeDom;
        using Microsoft.CSharp;
 
        class Bar {
          public string test = ""str1\n\t"";
          public void test()
          {
            Console.WriteLine(""str2"");
          }
        }
    }
}";
    
    static void Main(string[] args)
    {
      PrintStrings(GetStrings(programText));
      //Console.WriteLine("Hello World!");
    }
    static void PrintStrings(List<string> list)
    {
      list.ForEach(Console.WriteLine);
    }
    private static List<string> GetStrings(string sourceCode)
    {
      SyntaxTree tree = CSharpSyntaxTree.ParseText(sourceCode);
      CompilationUnitSyntax root = tree.GetCompilationUnitRoot();
      var collector = new StringsCollector();
      collector.Visit(root);
      return collector._strings;
    }
  }
}
Of course the code can be tweaked to cater for other needs.
