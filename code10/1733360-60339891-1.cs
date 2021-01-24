    var tree = CSharpSyntaxTree.ParseText(@"
      public class Foo
      {
          //Here some trivia to be removed
          public string bar = ""bar"";
      }");
    var Mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
    var compilation = CSharpCompilation.Create("MyCompilation",
        syntaxTrees: new[] { tree }, references: new[] { Mscorlib });
    var model = compilation.GetSemanticModel(tree);
    var root = model.SyntaxTree.GetRoot();
    
    var tr = new TriviaRemover();
    var newRoot = tr.Visit(root);
    
    Console.WriteLine(newRoot.GetText());
    Console.ReadLine();
