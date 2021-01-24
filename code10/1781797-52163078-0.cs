    public string extract(string xpath, string type)
        {
            string result = string.Empty;
            GeckoHtmlElement elm = null;
            GeckoWebBrowser wb = geckoWebBrowser1;//(GeckoWebBrowser)GetCurrentWB();
            if (wb != null)
            {
                elm = GetElement(wb, xpath);
                if (elm != null)
                    //UpdateUrlAbsolute(wb.Document, elm);
                if (elm != null)
                {
                    switch (type)
                    {
                        case "html":
                            result = elm.OuterHtml;
                            break;
                        case "text":
                            if (elm.GetType().Name == "GeckoTextAreaElement")
                            {
                                result = ((GeckoTextAreaElement)elm).Value;
                            }
                            else
                            {
                                result = elm.TextContent.Trim();
                            }
                            break;
                        case "value":
                            result = ((GeckoInputElement)elm).Value;
                            break;
                        default:
                            result = extractData(elm, type);
                            break;
                    }
                }
            }
            return result;
        }
        private string extractData(GeckoHtmlElement ele, string attribute)
        {
            var result = string.Empty;
            if (ele != null)
            {
                var tmp = ele.GetAttribute(attribute);
                /*if (tmp == null)
                {
                    tmp = extractData(ele.Parent, attribute);
                }*/
                if (tmp != null)
                    result = tmp.Trim();
            }
            return result;
        }
        private object GetCurrentWB()
        {
            if (tabControl1.SelectedTab != null)
            {
                if(tabControl1.SelectedTab.Controls.Count > 0)
                //if (tabControl1.SelectedTab.Controls.Count > 0)
                {
                    Control ctr = tabControl1.SelectedTab.Controls[0];
                    if (ctr != null)
                    {
                        
                        return ctr as object;
                    }
                }
            }
            return null;
        }
        private GeckoHtmlElement GetElement(GeckoWebBrowser wb, string xpath)
        {
            GeckoHtmlElement elm = null;
            if (xpath.StartsWith("/"))
            {
                if (xpath.Contains("@class") || xpath.Contains("@data-type"))
                {
                    var html = GetHtmlFromGeckoDocument(wb.Document);
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);
                    var node = doc.DocumentNode.SelectSingleNode(xpath);
                    if (node != null)
                    {
                        var currentXpath = "/" + node.XPath;
                        elm = (GeckoHtmlElement)wb.Document.EvaluateXPath(currentXpath).GetNodes().FirstOrDefault();
                    }
                }
                else
                {
                    elm = (GeckoHtmlElement)wb.Document.EvaluateXPath(xpath).GetNodes().FirstOrDefault();
                }
            }
            else
            {
                elm = (GeckoHtmlElement)wb.Document.GetElementById(xpath);
            }
            return elm;
        }
        private string GetHtmlFromGeckoDocument(GeckoDocument doc)
        {
            var result = string.Empty;
            GeckoHtmlElement element = null;
            var geckoDomElement = doc.DocumentElement;
            if (geckoDomElement is GeckoHtmlElement)
            {
                element = (GeckoHtmlElement)geckoDomElement;
                result = element.InnerHtml;
            }
            return result;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            var text = extract("/html/body/table[3]/tbody/tr[1]/td[2]/a[2]", "text");
            MessageBox.Show(text);
        }
