    public override DelimitedFieldBuilder AddField(string fieldName, string fieldType)
    {
        base.AddField(fieldName, fieldType);
        if (base.mFields.Count > 1)
        {
            base.LastField.FieldOptional = true;
            base.LastField.FieldQuoted = true;
            base.LastField.QuoteMode = QuoteMode.OptionalForBoth;
            base.LastField.QuoteMultiline = MultilineMode.AllowForBoth;
            // <New>
            base.LastField.TrimMode = TrimMode.Both;
            base.LastField.TrimChars = " \t"; // trim spaces and tabs
            // </New>
        }
        return base.LastField;
    } 
