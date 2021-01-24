        class Word_Merge
    {
        public static void Merge(string[] filesToMerge, string outputFilename, bool insertPageBreaks)
        {
            Word._Application wordApplication = new Word.Application();
            object pageBreak = Word.WdBreakType.wdSectionBreakContinuous;
            object outputFile = outputFilename;
            object fileName = @"S:\ODS\Insight 2 Oncology\Quality Division Project\Visual Review Scores\Scoring Template\MergeTemplate.docx";
            object end = Word.WdCollapseDirection.wdCollapseEnd;
            try
            {
                wordApplication.Visible = false;
                Word.Document wordDocument = wordApplication.Documents.Add(ref fileName);                
                Word.Selection selection = wordApplication.Selection;
               
                foreach (string file in filesToMerge)
                {
                    if (file.Contains("Scores.docx"))
                    {
                        selection.PageSetup.PaperSize = Word.WdPaperSize.wdPaper11x17;
                        selection.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;                      
                        selection.InsertFile(file);
                        selection.Collapse(ref end);
                    }                    
                    if (!file.Contains("Scores.docx") && insertPageBreaks)
                    {                        
                        selection.InsertFile(file);
                        selection.InsertBreak(pageBreak);
                    }
                }
                wordApplication.Selection.Document.Content.Select();
                wordDocument.PageSetup.TopMargin = (float)50;
                wordDocument.PageSetup.RightMargin = (float)50;
                wordDocument.PageSetup.LeftMargin = (float)50;
                wordDocument.PageSetup.BottomMargin = (float)50;
                selection.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle;
                selection.ParagraphFormat.SpaceAfter = 0.0F;
                selection.ParagraphFormat.SpaceBefore = 0.0F;
                wordDocument.SaveAs(outputFile + ".docx");
                wordDocument.Close();
                wordDocument = wordApplication.Documents.Open(outputFile + ".docx");
                wordDocument.ExportAsFixedFormat(outputFile + ".pdf", Word.WdExportFormat.wdExportFormatPDF);
                wordDocument = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                wordApplication.Quit();
            }
        }
    }
