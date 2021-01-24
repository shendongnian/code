    private List<string> returnPictureNodes(string xpathQuery, GeckoWebBrowser geckoWebBrowser)
        {
            List<string> arrNodes = new List<string>();
            try
            {
                GeckoImageElement img = (GeckoImageElement)geckoWebBrowser.Document.SelectSingle(xpathQuery);
                arrNodes.Add(removeCarriageReturnsFromString(img.Src));                
            }
            catch (Exception ex)
            {
                MessageBox.Show(xpathQuery + " => " + ex.Message);
            }
            return arrNodes;
        }
