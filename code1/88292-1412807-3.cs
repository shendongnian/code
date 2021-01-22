            if (webBrowser1.Document != null)
            {
                IHTMLDocument2 document = webBrowser1.Document.DomDocument as IHTMLDocument2;
                if (document != null)
                {
                    IHTMLBodyElement bodyElement = document.body as IHTMLBodyElement;
                    if (bodyElement != null)
                    {
                        IHTMLTxtRange trg = bodyElement.createTextRange();
                        if (trg != null)
                        {
                            const String SearchString = "Privacy"; // This is the search string you're looking for.
                            const int wordStartOffset = 421; // This is the starting position in the HTML where the word you're looking for starts at.
                            int wordEndOffset = SearchString.Length;
                            trg.move("character", wordStartOffset);
                            trg.moveEnd("character", wordEndOffset);
                            trg.select();
                        }
                    }
                }
            }
