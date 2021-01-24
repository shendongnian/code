        private void btnReplaceBookmarkText_Click(object sender, EventArgs e)
        {
            string fileNameDoc = "path name";
            string bkmName = "signet";
            string bkmID = "";
            string parentTypeStart = "";
            string parentTypeEnd = "";
            using (WordprocessingDocument pkgDoc = WordprocessingDocument.Open(fileNameDoc, true))
            {
                Body body = pkgDoc.MainDocumentPart.Document.Body;
                BookmarkStart bkmStart = body.Descendants<BookmarkStart>().Where(bkm => bkm.Name == bkmName).FirstOrDefault();
                bkmID = bkmStart.Id;
                BookmarkEnd bkmEnd = body.Descendants<BookmarkEnd>().Where(bkm => bkm.Id == bkmID).FirstOrDefault();
                parentTypeStart = bkmStart.Parent.LocalName;
                parentTypeEnd = bkmEnd.Parent.LocalName;
                int counter = 0;
                if (parentTypeStart == "p" && parentTypeEnd == "p") 
                { //bookmark starts at a paragraph and ends within a paragraph
                    Paragraph bkmParaStart = (Paragraph) bkmStart.Parent;
                    Paragraph bkmParaEnd = (Paragraph) bkmEnd.Parent;
                    Paragraph bkmParaNext = (Paragraph) bkmParaStart; 
                    List<Paragraph> paras = new List<Paragraph>();
                    paras.Add(bkmParaStart);
                    
                    BookmarkEnd x = bkmParaNext.Descendants<BookmarkEnd>().Where(bkm => bkm.Id == bkmID).FirstOrDefault();
                    while (x==null) 
                    {
                        Paragraph nextPara = (Paragraph) bkmParaNext.NextSibling();
                        if (nextPara != null)
                        {
                            paras.Add(nextPara);
                            bkmParaNext = (Paragraph)nextPara.Clone();
                            x = bkmParaNext.Descendants<BookmarkEnd>().Where(bkm => bkm.Id == bkmID).FirstOrDefault();
                        }
                    }
                    foreach (Paragraph para in paras)
                    {
                        string t = "changed string once more " + counter;
                        Run firstRun = para.Descendants<Run>().FirstOrDefault();
                        Run newRun = (Run) firstRun.Clone();
                        newRun.RemoveAllChildren<Text>();
                        para.RemoveAllChildren<Run>();
                        para.RemoveAllChildren<Text>();
                        para.AppendChild<Run>(newRun).AppendChild<Text>(new Text(t));
                    }
                    //After replacing the runs and text the bookmark is at the beginning
                    //of the paragraph, we want it at the end
                    BookmarkEnd newBkmEnd = new BookmarkEnd() { Id = bkmID };
                    Paragraph p = paras.Last<Paragraph>();
                    p.Descendants<BookmarkEnd>().Where(bkm => bkm.Id==bkmID).FirstOrDefault().Remove();
                    p.Append(newBkmEnd);
                }
            }  
        }
