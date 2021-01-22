    <add assembly="Microsoft.Vsa, Version=8.0.0.0, Culture=neutral, PublicKeyToken=B03F5F7F11D50A3A"/></assemblies>
----
        
        using Microsoft.JScript;
        
        public class MyClass {
        
        public static Microsoft.JScript.Vsa.VsaEngine Engine = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();
         
            public static object EvaluateScript(string script)
            {
                object Result = null;
                try
                {
                    Result = Microsoft.JScript.Eval.JScriptEvaluate(JScript, Engine);
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
         
                return Result;
            }
            
            public void MyMethod() {
                string myscript = ...;
                object myresult = EvaluateScript(myscript);
            }
        
        
        }
