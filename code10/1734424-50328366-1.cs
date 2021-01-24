        private void btnDataToMergeFields_Click(object sender, EventArgs e)
        {
            getWordInstance();
            if (wdApp != null)
            {
                if (wdApp.Documents.Count > 0)
                {
                Word.Document doc = wdApp.ActiveDocument;
                Word.Range rng = doc.Content;
                Word.ShapeRange rngShapes = rng.ShapeRange;
                if (doc.MailMerge.MainDocumentType != Word.WdMailMergeMainDocType.wdNotAMergeDocument)
                    foreach (Word.MailMergeDataField mmDataField in doc.MailMerge.DataSource.DataFields)
                    {
                      System.Diagnostics.Debug.Print(ReplaceTextWithMergeField(mmDataField.Name, ref rng).ToString() 
                          + " merge fields inserted for " + mmDataField.Name);
                      rng = doc.Content;
                      System.Diagnostics.Debug.Print(ReplaceTextWithMergeFieldInShapes(mmDataField.Name, ref rngShapes)
                          + " mergefields inserted for " + mmDataField.Name);
                    }
                }
            }
        }
        //returns the number of times the merge field was inserted
        public int ReplaceTextWithMergeField(string sFieldName, ref Word.Range oRng)
        {
            int iFieldCounter = 0;
            Word.Field fldMerge;
            bool bFound;
            oRng.Find.ClearFormatting();
            oRng.Find.Forward = true;
            oRng.Find.Wrap = Word.WdFindWrap.wdFindStop;
            oRng.Find.Format = false;
            oRng.Find.MatchCase = false;
            oRng.Find.MatchWholeWord = false;
            oRng.Find.MatchWildcards = false;
            oRng.Find.MatchSoundsLike = false;
            oRng.Find.MatchAllWordForms = false;
            oRng.Find.Text = "<<" + sFieldName + ">>";
            bFound = oRng.Find.Execute();
            while (bFound)
            {
                iFieldCounter = iFieldCounter + 1;
                fldMerge = oRng.Fields.Add(oRng, Word.WdFieldType.wdFieldMergeField, sFieldName, false);
                oRng = fldMerge.Result;
                oRng.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
                oRng.MoveStart(Word.WdUnits.wdCharacter, 2);
                oRng.End = oRng.Document.Content.End;
                oRng.Find.Text = "<<" + sFieldName + ">>";
                bFound = oRng.Find.Execute();
            }
            return iFieldCounter;
        }
        public int ReplaceTextWithMergeFieldInShapes(string sFieldName,
                                   ref Word.ShapeRange oRng)
        {
            int iFieldCounter = 0;
            Word.Field fldMerge;
            bool bFound;
            foreach (Word.Shape shp in oRng)
            {
                if (shp.Type == Office.MsoShapeType.msoTextBox)
                {
                    Word.Range rngText = shp.TextFrame.TextRange;
                    rngText.Find.ClearFormatting();
                    rngText.Find.Forward = true;
                    rngText.Find.Wrap = Word.WdFindWrap.wdFindStop;
                    rngText.Find.Format = false;
                    rngText.Find.MatchCase = false;
                    rngText.Find.MatchWholeWord = false;
                    rngText.Find.MatchWildcards = false;
                    rngText.Find.MatchSoundsLike = false;
                    rngText.Find.MatchAllWordForms = false;
                    rngText.Find.Text = "<<" + sFieldName + ">>";
                    bFound = rngText.Find.Execute();
                    while (bFound)
                    {
                        iFieldCounter = iFieldCounter + 1;
                        fldMerge = rngText.Fields.Add(rngText, Word.WdFieldType.wdFieldMergeField, sFieldName, false);
                        rngText = fldMerge.Result;
                        rngText.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
                        rngText.MoveStart(Word.WdUnits.wdCharacter, 2);
                        rngText.End = shp.TextFrame.TextRange.End;
                        rngText.Find.Text = sFieldName;
                        bFound = rngText.Find.Execute();
                    }
                }
            }
            return iFieldCounter;
        }
