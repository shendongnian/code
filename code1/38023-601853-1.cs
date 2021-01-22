       TextRange tr = new TextRange(myRichTextBox.Document.ContentStart,
                                    myRichTextBox.Document.ContentEnd);
       MemoryStream ms = new MemoryStream();
       tr.Save(ms, DataFormats.Xaml);
       string xamlText = ASCIIEncoding.Default.GetString(ms.ToArray());
