    private void FillBookmarksUsingOpenXml(string sourceDoc, string destDoc, Dictionary<string, string> bookmarkData)
        {
            string wordmlNamespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
            // Make a copy of the template file.
            File.Copy(sourceDoc, destDoc, true);
            //Open the document as an Open XML package and extract the main document part.
            using (WordprocessingDocument wordPackage = WordprocessingDocument.Open(destDoc, true))
            {
                MainDocumentPart part = wordPackage.MainDocumentPart;
                //Setup the namespace manager so you can perform XPath queries 
                //to search for bookmarks in the part.
                NameTable nt = new NameTable();
                XmlNamespaceManager nsManager = new XmlNamespaceManager(nt);
                nsManager.AddNamespace("w", wordmlNamespace);
                //Load the part's XML into an XmlDocument instance.
                XmlDocument xmlDoc = new XmlDocument(nt);
                xmlDoc.Load(part.GetStream());
                //Iterate through the bookmarks.
                foreach (KeyValuePair<string, string> bookmarkDataVal in bookmarkData)
                {
                    var bookmarks = from bm in part.Document.Body.Descendants<BookmarkStart>()
                              select bm;
                    foreach (var bookmark in bookmarks)
                    {
                        if (bookmark.Name == bookmarkDataVal.Key)
                        {
                            Run bookmarkText = bookmark.NextSibling<Run>();
                            if (bookmarkText != null)  // if the bookmark has text replace it
                            {
                                bookmarkText.GetFirstChild<Text>().Text = bookmarkDataVal.Value;
                            }
                            else  // otherwise append new text immediately after it
                            {
                                var parent = bookmark.Parent;   // bookmark's parent element
                                Text text = new Text(bookmarkDataVal.Value);
                                Run run = new Run(new RunProperties());
                                run.Append(text);
                                // insert after bookmark parent
                                parent.Append(run);
                            }
                            //bk.Remove();    // we don't want the bookmark anymore
                        }
                    }
                }
                //Write the changes back to the document part.
                xmlDoc.Save(wordPackage.MainDocumentPart.GetStream(FileMode.Create));
            }
        }
