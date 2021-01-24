    TextLoader tl = new TextLoader(inputFileName)
    tl.Arguments.HasHeader = useHeader;
    tl.Arguments.Separator = new[] { separator };
    tl.Arguments.AllowQuoting = allowQuotedStrings;
    tl.Arguments.AllowSparse = supportSparse;
    tl.Arguments.TrimWhitespace = trimWhitespace;
