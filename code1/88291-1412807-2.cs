            if (webBrowser1.Document != null)
            {
                IHTMLDocument2 document = webBrowser1.Document.DomDocument as IHTMLDocument2;
                if (document != null)
                {
                    IMarkupServices ims = document as IMarkupServices;
                    IHTMLBodyElement bodyElement = document.body as IHTMLBodyElement;
                    if (bodyElement != null)
                    {
                        IHTMLTxtRange trg = bodyElement.createTextRange();
                        if (trg != null)
                        {
                            trg.move("character", 500);
                            trg.moveEnd("character", 50);
                            trg.select();
                        }
                    }
                }
            }
