    //small but important modification to class http://htmlagilitypack.codeplex.com/sourcecontrol/changeset/view/62772#52179
    public static class HtmlToText
    {
        public static string Convert(string path)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(path);
            return ConvertDoc(doc);
        }
        public static string ConvertHtml(string html)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            return ConvertDoc(doc);
        }
        public static string ConvertDoc (HtmlDocument doc)
        {
            using (StringWriter sw = new StringWriter())
            {
                ConvertTo(doc.DocumentNode, sw);
                sw.Flush();
                sw.GetStringBuilder().TrimStart().ToString();
                return sw.ToString();
            }
        }
        private static StringBuilder TrimStart(this StringBuilder sb)
        {
            int pos=0;
            while (pos<sb.Length && char.IsWhiteSpace(sb[pos])){pos++;}
            if (pos == 0) { return sb; }
            sb.Remove(0, pos);
            return sb;
        }
        private static void ConvertContentTo(HtmlNode node, TextWriter outText)
        {
            foreach (HtmlNode subnode in node.ChildNodes)
            {
                ConvertTo(subnode, outText);
            }
        }
        public static void ConvertTo(HtmlNode node, TextWriter outText)
        {
            string html;
            switch (node.NodeType)
            {
                case HtmlNodeType.Comment:
                    // don't output comments
                    break;
                case HtmlNodeType.Document:
                    ConvertContentTo(node, outText);
                    break;
                case HtmlNodeType.Text:
                    // script and style must not be output
                    string parentName = node.ParentNode.Name;
                    if ((parentName == "script") || (parentName == "style"))
                        break;
                    // get text
                    html = ((HtmlTextNode)node).Text;
                    // is it in fact a special closing node output as text?
                    if (HtmlNode.IsOverlappedClosingElement(html))
                        break;
                    // check the text is meaningful and not a bunch of whitespaces
                    html = html.Trim();
                    if (html.Length > 0)
                    {
                        outText.Write(HtmlEntity.DeEntitize(Regex.Replace(html, @"\s{2,}", " ")));
                    }
                    break;
                case HtmlNodeType.Element:
                    string endElementString = null;
                    switch (node.Name)
                    {
                        case "p":
                        case "div": // stylistic - adjust as you tend to use
                            outText.Write("\r\n");
                            endElementString = "\r\n";
                            break;
                        case "a":
                            if (node.Attributes.Contains("href"))
                            {
                                string href = node.Attributes["href"].Value;
                                if (node.InnerText.IndexOf(href, StringComparison.InvariantCultureIgnoreCase)==-1)
                                {
                                    endElementString =  "<" + href + ">";
                                }  
                            }
                            break;
                        case "li": //not doing ol li elements at this stage
                            outText.Write("\r\n\t-"); //using '-' as bullet char, but whatever you want
                            break;
                        case "ul":
                            endElementString = "\r\n";
                            break;
                    }
                    if (node.HasChildNodes)
                    {
                        ConvertContentTo(node, outText);
                        if (endElementString!=null)
                        {
                            outText.Write(endElementString);
                        }
                    }
                    break;
            }
        }
    }
