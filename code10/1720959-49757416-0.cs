            Word._Application oWord;
            object oMissing = Type.Missing;
            oWord = Globals.ThisAddIn.Application;
            int sectionIndex = oWord.Selection.Information[Word.WdInformation.wdActiveEndSectionNumber];
            Word.Section wordSection;
            Word.HeaderFooter hf;
            if (sectionIndex != oWord.ActiveDocument.Sections.Count) { 
            wordSection = oWord.ActiveDocument.Sections[sectionIndex+1];
            hf = wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
            hf.LinkToPrevious = false;
            }
            wordSection = oWord.ActiveDocument.Sections[sectionIndex];
            hf = wordSection.Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
            hf.LinkToPrevious = false;
            hf.Range.Font.Size = 7;
            hf.Range.Font.ColorIndex = Word.WdColorIndex.wdBlack;
            hf.Range.Text = "Inserting Footer Text in current section of a document";
