    private void LeaveDotsAndSlashesEscaped()
    {
        var getSyntaxMethod = 
            typeof (UriParser).GetMethod("GetSyntax", BindingFlags.Static | BindingFlags.NonPublic);
        if (getSyntaxMethod == null)
        {
            throw new MissingMethodException("UriParser", "GetSyntax");
        }
        var uriParser = getSyntaxMethod.Invoke(null, new object[] { "http" });
        var setUpdatableFlagsMethod = 
            uriParser.GetType().GetMethod("SetUpdatableFlags", BindingFlags.Instance | BindingFlags.NonPublic);
        if (setUpdatableFlagsMethod == null)
        {
            throw new MissingMethodException("UriParser", "SetUpdatableFlags");
        }
        setUpdatableFlagsMethod.Invoke(uriParser, new object[] {0});
    }
