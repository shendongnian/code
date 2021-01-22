    if (webBrowser.Document != null)
                {
                    IHTMLDocument2 HtmlDoc = (IHTMLDocument2)webBrowser.Document.DomDocument;
                    IHTMLElement targetElement = null;
                    foreach (IHTMLElement domElement in HtmlDoc.all)
                    {
                        if (domElement.sourceIndex == int.Parse(node.InnerText))// fetching the persisted data from the XML file.
                        {
                            targetElement = domElement;
                            break;
                        }
                    }
                    MessageBox.Show(targetElement.innerText); //range.parentElement().sourceIndex
                }
