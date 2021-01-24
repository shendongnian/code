    using Microsoft.CodeAnalysis.CSharp.Scripting;
    static async Task Main(string[] args)
    {
        var state = await CSharpScript.RunAsync("var a = 42;");
        Console.WriteLine(state.GetVariable("a").Value);
    }
