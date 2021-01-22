    using MSScriptControl; // references msscript.ocx
    
    ScriptControlClass sc = new ScriptControlClass();
    sc.Language = "VBScript";
    sc.AllowUI = true;
    
    // VBScript engine doesn’t have IIf function
    // Adding wraper IIF function to script control.
    // This IIF function will work just as VB6 IIf function.
    sc.AddCode(@"Function IIF(Expression,TruePart,FalsePart)
                    If Expression Then
                        IIF=TruePart
                    Else
                        IIF=FalsePart
                    End IF
                End Function");
    try
    {
        //define x,y variable with value
        sc.AddCode(@"x=5
                    y=6");
        //test our IIF 
        Console.WriteLine(sc.Eval("IIF(x>y,x,y)").ToString());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
