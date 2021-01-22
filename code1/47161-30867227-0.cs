     public string StripHTML(WebBrowser webp)
            {
                try
                {
                    doc.execCommand("SelectAll", true, null);
                    IHTMLSelectionObject currentSelection = doc.selection;
    
                    if (currentSelection != null)
                    {
                        IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;
                        if (range != null)
                        {
                            currentSelection.empty();
                            return range.text;
                        }
                    }
                }
                catch (Exception ep)
                {
                    //MessageBox.Show(ep.Message);
                }
                return "";
    
            }
