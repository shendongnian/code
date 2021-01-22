    formatter.Transforms.Add(new KeyValuePair<string, Func<string, string>>(formatter.ReservedColumnNameWholeLine, s => {
        // Make other replacements.
        s = s.Replace(@"BegAtt|EndAtt", "BegAtt#|EndAtt#");
        s = s.Replace(@"Cc|*RFP", "CC|RFP");
        s = s.Replace(@"<swme> ", string.Empty);
        s = s.Replace(@" </swme>", ";");
        return s;
    }));
