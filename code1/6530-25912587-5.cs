    string sFunc = @"Function InBox(prompt, title, default) 
    InBox = InputBox(prompt, title, default)    
    End Function
    ";
    Type tScriptControl = Type.GetTypeFromProgID("ScriptControl");
    object oSC = Activator.CreateInstance(tScriptControl);
    // https://github.com/mono/mono/blob/master/mcs/class/corlib/System/MonoType.cs
    // System.Reflection.PropertyInfo pi = tScriptControl.GetProperty("Language", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.CreateInstance| System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.IgnoreCase);
    // pi.SetValue(oSC, "VBScript", null);
    tScriptControl.InvokeMember("Language", System.Reflection.BindingFlags.SetProperty, null, oSC, new object[] { "VBScript" });
    tScriptControl.InvokeMember("AddCode", System.Reflection.BindingFlags.InvokeMethod, null, oSC, new object[] { sFunc });
    object ret = tScriptControl.InvokeMember("Run", System.Reflection.BindingFlags.InvokeMethod, null, oSC, new object[] { "InBox", "メッセージ", "タイトル", "初期値" });
    Console.WriteLine(ret);
