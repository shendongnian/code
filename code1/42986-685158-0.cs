           public bool WebPageLoaded
        {
            get
            {
                if (this.WebBrowser.ReadyState != System.Windows.Forms.WebBrowserReadyState.Complete)
                    return false;
                if (this.HtmlDomDocument == null)
                    return false;
                // iterate over all the Html elements. Find all frame elements and check their ready state
                foreach (IHTMLDOMNode node in this.HtmlDomDocument.all)
                {
                    IHTMLFrameBase2 frame = node as IHTMLFrameBase2;
                    if (frame != null)
                    {
                        if (!frame.readyState.Equals("complete", StringComparison.OrdinalIgnoreCase))
                            return false;
                    }
                }
                Debug.Print(this.Name + " - I think it's loaded");
                return true;
            }
        }
