    // System.UriSyntaxFlags is internal, so let's duplicate the flag privately
    private const int UnEscapeDotsAndSlashes = 0x2000000;
    private void LeaveDotsAndSlashesEscaped()
    {
        var getSyntaxMethod = 
            typeof (UriParser).GetMethod("GetSyntax", BindingFlags.Static | BindingFlags.NonPublic);
        if (getSyntaxMethod == null)
        {
            throw new MissingMethodException("UriParser", "GetSyntax");
        }
    
        var uriParser = getSyntaxMethod.Invoke(null, new object[] { "http" });
    
        FieldInfo flagsFieldInfo = typeof(UriParser).GetField("m_Flags", BindingFlags.NonPublic | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.Instance);
        if (flagsFieldInfo == null)
        {
            throw new MissingFieldException("UriParser", "m_Flags");
        }
        int flags = (int) flagsFieldInfo.GetValue(uriParser);
        // unset UnEscapeDotsAndSlashes flag and leave the others untouched
        flags = flags & ~UnEscapeDotsAndSlashes;
        flagsFieldInfo.SetValue(uriParser, flags);
    }
