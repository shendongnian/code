     Word.Application wordApp = null;
        // word document
        document = null;
        try
        {
            wordApp = new Word.Application();
            //WordApp.Visible = true;
            // open
            document = wordApp.Application.Documents.Open(wordpath);
            Word.Range permittedRange = document.Content;
            permittedRange.Editors.Add(Word.WdEditorType.wdEditorEveryone);
            foreach (Word.Section wordSection in document.Sections)
            {
                //Allow editing the headers?
                permittedRange = wordSection.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                permittedRange.Editors.Add(Word.WdEditorType.wdEditorEveryone);
                //Get the footer range and add the footer details.
                Word.Range footerRange = wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                footerRange.Font.ColorIndex = Word.WdColorIndex.wdGray50;
                footerRange.Font.Size = 15;
                footerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                footerRange.Text = wordHeaderName;
            }
            document.Protect(Word.WdProtectionType.wdAllowOnlyReading, ref missing, ref missing, ref missing, ref missing);
            // save 
            document.Save();
