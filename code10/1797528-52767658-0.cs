    var src = @"public class Test
    {
        public IList<string> CallMe(int count = 10)
        {
            return Enumerable.Range(0, count).Select(x => $""Number-{x}"").ToList();
        }
    }";
    var options = ScriptOptions.Default
        .AddReferences("mscorlib", "System.Core") // assume that it's run under .netframework
        .AddImports("System", "System.Linq", "System.Collections.Generic");
    var list = CSharpScript.RunAsync(src, options).Result
                           .ContinueWithAsync<IList<string>>("new Test().CallMe(20)").Result.ReturnValue;
