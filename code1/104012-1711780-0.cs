    [Guid("626FC520-A41E-11CF-A731-00A0C9082637"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
    interface IHTMLDocument
    {
        void Script([Out, MarshalAs(UnmanagedType.Interface)] out object ppScript);
    }
    public object RunScript(InternetExplorer ie, string scriptText)
    {                        
        IHTMLDocument doc = (IHTMLDocument)ie.Document;
        object scriptObj;
        doc.Script(out scriptObj);
        Type t = scriptObj.GetType();
        return t.InvokeMember("eval", System.Reflection.BindingFlags.InvokeMethod, null, scriptObj, new object[] { scriptText });            
    }
