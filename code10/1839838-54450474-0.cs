    using (var writer = new StringWriter ()) {
        using (var reader = new StringReader (html)) {
            var tokenizer = new HtmlTokenizer (reader) {
                DecodeCharacterReferences = true
            };
            HtmlToken token;
    
            while (tokenizer.ReadNextToken (out token)) {
                switch (token.Kind) {
                case HtmlTokenKind.Data:
                    var data = (HtmlDataToken) token;
                    writer.Write (data.Data);
                    break;
                case HtmlTokenKind.Tag:
                    var tag = (HtmlTagToken) token;
                    switch (tag.Id) {
                    case HtmlTagId.Br:
                        writer.Write (Environment.NewLine);
                        break;
                    case HtmlTagId.P:
                        if (tag.IsEndTag || tag.IsEmptyElement)
                            writer.Write (Environment.NewLine);
                        break;
                    }
                    break;
                }
            }
        }
    
        return writer.ToString ();
    }
