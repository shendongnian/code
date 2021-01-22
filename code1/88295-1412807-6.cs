            if (webBrowser1.Document != null)
            {
                IHTMLDocument2 document = webBrowser1.Document.DomDocument as IHTMLDocument2;
                if (document != null)
                {
                    IHTMLSelectionObject currentSelection = document.selection;
                    IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;
                    if (range != null)
                    {
                       const String search = "Privacy";
                       if (range.findText(search, search.Length, 2))
                       {
                           range.select();
                       }
                    }
                }
            }
       
