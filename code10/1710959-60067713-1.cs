using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
namespace CodeScanner
{
  class StringsCollector : CSharpSyntaxWalker
  {
    public List<String> _strings = new List<string>();
    
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
    private const string _rootDir = @"<replace here with your root dir>";
    static List<string> GetAllCSharpCode(string folder)
    {
      List<string> result = new List<string>();
      result.AddRange(Directory.GetFiles(folder, "*.cs"));
      foreach (var directory in Directory.GetDirectories(folder).Where(d => !SkipDirectory(d)))
      {
      
        result.AddRange(GetAllCSharpCode(directory));
      }
      return result;
    }
    private static string[] skippedDirs = new string[] {"obj", "packages"};
    static bool SkipDirectory(string directory)
    {
      var lcDir = directory.ToLower();
      return skippedDirs.Any(sd => directory.EndsWith("\\" + sd));
    }
    static void Main(string[] args)
    {
      //PrintStrings(GetStrings(programText));
      //Console.WriteLine("Hello World!");
      var allCSharpFiles = GetAllCSharpCode(_rootDir);
      
      PrintStrings(allCSharpFiles);
      
      allCSharpFiles.ForEach(f =>
      {
        Console.WriteLine(f);
        PrintStrings(GetStrings(File.ReadAllText(f)));
      });
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
Of course the code can be tweaked to cater for other requirements.
