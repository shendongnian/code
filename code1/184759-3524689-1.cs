    string noComments = Regex.Replace(input,
        blockComments + "|" + lineComments + "|" + strings + "|" + verbatimStrings,
        me => {
            if (me.Value.StartsWith("/*") || me.Value.StartsWith("//"))
                return me.Value.StartsWith("//") ? Environment.NewLine : "";
            // Keep the literal strings
            return me.Value;
        },
        RegexOptions.Singleline);
