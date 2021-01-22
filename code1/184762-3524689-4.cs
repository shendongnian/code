    var list = new List<string>();
    string noComments = Regex.Replace(input,
        blockComments + "|" + lineComments + "|" + strings + "|" + verbatimStrings,
        me => {
            if (me.Value.StartsWith("/*") || me.Value.StartsWith("//")) {
                // Add the contents of comments to the list
                list.Add(me.Groups[1].Value + me.Groups[2].Value);
                return me.Value.StartsWith("//") ? Environment.NewLine : "";
            }
            // Keep the literal strings
            return me.Value;
        },
        RegexOptions.Singleline);
