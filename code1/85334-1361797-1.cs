    int[] i = new int[3] { 1, 2, 3 };        
    string msg = "";        
    object[] myParam = { msg , i};        
    MSScriptControl.ScriptControlClass sc 
       = new MSScriptControl.ScriptControlClass();
    sc.Language = "VBScript";
    sc.AddCode("Function Test(ByRef msg, ByRef aryI) as String" + 
    Environment.NewLine +  "  msg = \"234\"" + 
    Environment.NewLine +  "  Test = msg" + // this Test=msg is a return statement
    Environment.NewLine + "End Function");
    
    msg = (string)sc.Run("Test", ref myParam);
    or 
    msg = (string)sc.Eval("Test",ref myParam);
