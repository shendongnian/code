    // System.UriSyntaxFlags is internal, so let's duplicate the flag privately
    private const int UnEscapeDotsAndSlashes = 0x2000000;
 
    public static void LeaveDotsAndSlashesEscaped(Uri uri)
    {
        if (uri == null)
        {
            throw new ArgumentNullException("uri");
        }
 
        FieldInfo fieldInfo = uri.GetType().GetField("m_Syntax", BindingFlags.Instance | BindingFlags.NonPublic);
        if (fieldInfo == null)
        {
            throw new MissingFieldException("'m_Syntax' field not found");
        }
        object uriParser = fieldInfo.GetValue(uri);
 
        fieldInfo = typeof(UriParser).GetField("m_Flags", BindingFlags.Instance | BindingFlags.NonPublic);
        if (fieldInfo == null)
        {
            throw new MissingFieldException("'m_Flags' field not found");
        }
        object uriSyntaxFlags = fieldInfo.GetValue(uriParser);
 
        // Clear the flag that we don't want
        uriSyntaxFlags = (int)uriSyntaxFlags & ~UnEscapeDotsAndSlashes;
 
        fieldInfo.SetValue(uriParser, uriSyntaxFlags);
    }
