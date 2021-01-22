                return builderHTML.ToString();
               
            }
            private static void ProcessURLS(ExtendedWebBrowser browser, StringBuilder builderHTML, string strLink, string strHref)
            {
                for (int k = 0; k < browser.Document.Body.Parent.GetElementsByTagName(strLink).Count; k++)
                {
                    string strURL = browser.Document.Body.Parent.GetElementsByTagName(strLink)[k].GetAttribute(strHref);
                    string strOuterHTML = browser.Document.Body.Parent.GetElementsByTagName(strLink)[k].OuterHtml;
                    string[] strlist = strOuterHTML.Split(new string[] { " " }, StringSplitOptions.None);
                    StringBuilder builder = new StringBuilder();
                    for (int p = 0; p < strlist.Length; p++)
                    {
                        if (strlist[p].StartsWith(strHref))                        
                            builder.Append (strlist[p].Contains("http")? strlist[p] + " ":
                                (strURL.StartsWith("http") ?  strHref + "=" + strURL + " ":
                                    strHref + "= " + "http://xyz.com" + strURL + " " ));                           
                        else
                            builder.Append(strlist[p] + " ");
                    }
                    builderHTML.Replace(strOuterHTML, builder.ToString());
                }
            }
