    static void CreateCompileAndRun()
    {
        AppDomain domain = AppDomain.CreateDomain("MyDomain");
        CompilerRunner cr = (CompilerRunner)domain.CreateInstanceFromAndUnwrap("CompilerRunner.dll", "AppDomainCompiler.CompilerRunner");            
        cr.Compile("public class Hello { public static string Say() { return \"hello\"; } }");            
        string result = (string)cr.Run("Hello", "Say", new object[0]);
        
        AppDomain.Unload(domain);
    }
