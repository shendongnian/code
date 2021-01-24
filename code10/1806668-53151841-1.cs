        private void Bold_Click(object sender, RoutedEventArgs e)
       {
        //I get the document from richEditBox.Document for my test, you can get yours
        ITextDocument textDocument = richEditBox.Document;
        ITextCharacterFormat textCharacterFormat = textDocument.GetDefaultCharacterFormat();
        textCharacterFormat.Bold = FormatEffect.On;
        
        string stringToTest;
        string patternToMatch = @"\bhello\b";
        ITextRange textRange;
        textDocument.GetText(TextGetOptions.None, out stringToTest);
        Regex regex = new Regex(patternToMatch, RegexOptions.Compiled);
        MatchCollection matches = regex.Matches(stringToTest);
        foreach (Match match in matches)
        {
            textRange = textDocument.GetRange(match.Index, match.Index + 5);
            textRange.CharacterFormat = textCharacterFormat;
        }
       }
