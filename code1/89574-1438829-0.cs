    using Microsoft.JScript;        // needs a reference to Microsoft.JScript.dll
    using Microsoft.JScript.Vsa;    // needs a reference to Microsoft.Vsa.dll
    // ...
    string expr = "7 + (5 * 4)";
    Console.WriteLine(JScriptEval(expr));    // displays 27
    // ...
    public static VsaEngine _engine = VsaEngine.CreateEngine();
    public static double JScriptEval(string expr)
    {
        // error checking etc removed for brevity
        return double.Parse(Eval.JScriptEvaluate(expr, _engine).ToString());
    }
