    MethodInfo getSyntax = typeof(UriParser).GetMethod("GetSyntax", System.Reflection.BindingFlags.Static
                                                                  | System.Reflection.BindingFlags.NonPublic);
    FieldInfo flagsField = typeof(UriParser).GetField("m_Flags", System.Reflection.BindingFlags.Instance
                                                               | System.Reflection.BindingFlags.NonPublic);
    if (getSyntax != null && flagsField != null)
    {
        UriParser parser = (UriParser)getSyntax.Invoke(null, new object[] { "ftp"});
        if (parser != null)
        {
            int flagsValue = (int)flagsField.GetValue(parser);
            // Set the MayHaveQuery attribute
            int MayHaveQuery = 0x20;
            if ((flagsValue & MayHaveQuery) == 0) flagsField.SetValue(parser, flagsValue | MayHaveQuery);
        }
    }
