    var blockComments = @"/\*(.*?)\*/";
    var lineComments = @"//(.*?)\r?\n";
    var strings = @"""((\\\[^\n]|[^""\n])*)""";
    var verbatimStrings = @"@(""[^""]*"")+";
    string noComments = Regex.Replace(input,
        blockComments + "|" + lineComments + "|" + strings + "|" + verbatimStrings,
        me => {
            if (me.Value.StartsWith("/*") || me.Value.StartsWith("//")) {
                // Put the contents of comments into the list
                list.Add(me.Groups[1].Value + me.Groups[2].Value);
                // Replace the comments with empty, i.e. remove them
                return me.Value.StartsWith("//") ? Environment.NewLine : "";
            }
            // Keep the literal strings
            return me.Value;
        },
        RegexOptions.Singleline);
