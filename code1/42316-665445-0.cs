    Assembly asm = Assembly.LoadFile(DLL_Path);
    Type t = asm.GetType(DLL_NameSpace.MyClass, false, true);
    clsMethodInvoke mi = new clsMethodInvoke();
    foreach (MemberInfo oMember in t.GetMembers(mi.GetFilter()))
    {
        string parameters = GetParameters(oMember);
        string test = String.Format(testTemplate, t.Name, m.Name, parameters);
        // Feed test string to T4.
    }
