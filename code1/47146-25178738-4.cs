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
                return sw.ToString();
            }
        }
        internal static void ConvertContentTo(HtmlNode node, TextWriter outText, PreceedingDomTextInfo textInfo)
        {
            foreach (HtmlNode subnode in node.ChildNodes)
            {
                ConvertTo(subnode, outText, textInfo);
            }
        }
        public static void ConvertTo(HtmlNode node, TextWriter outText)
        {
            ConvertTo(node, outText, new PreceedingDomTextInfo { IsFirstElementOfDoc = true });
        }
        internal static void ConvertTo(HtmlNode node, TextWriter outText, PreceedingDomTextInfo textInfo)
        {
            string html;
            switch (node.NodeType)
            {
                case HtmlNodeType.Comment:
                    // don't output comments
                    break;
                case HtmlNodeType.Document:
                    ConvertContentTo(node, outText, textInfo);
                    break;
                case HtmlNodeType.Text:
                    // script and style must not be output
                    string parentName = node.ParentNode.Name;
                    if ((parentName == "script") || (parentName == "style"))
                    {
                        break;
                    }
                    // get text
                    html = ((HtmlTextNode)node).Text;
                    // is it in fact a special closing node output as text?
                    if (HtmlNode.IsOverlappedClosingElement(html))
                    {
                        break;
                    }
                    // check the text is meaningful and not a bunch of whitespaces
                    if (html.Length == 0)
                    {
                        break;
                    }
                    if (!textInfo.FirstTextOfBlockWritten || textInfo.LastCharWasSpace)
                    {
                        html= html.TrimStart();
                        if (html.Length == 0) { break; }
                        textInfo.FirstTextOfBlockWritten = true;
                    }
                    outText.Write(HtmlEntity.DeEntitize(Regex.Replace(html.TrimEnd(), @"\s{2,}", " ")));
                    if (textInfo.LastCharWasSpace = char.IsWhiteSpace(html[html.Length - 1]))
                    {
                        outText.Write(' ');
                    }
                        break;
                case HtmlNodeType.Element:
                    string endElementString = null;
                    bool isInline;
                    switch (node.Name)
                    {
                        case "p":
                        case "div": // stylistic - adjust as you tend to use
                            if (textInfo.IsFirstElementOfDoc)
                            { textInfo.IsFirstElementOfDoc = false; }
                            else
                            { outText.Write("\r\n"); }
                            endElementString = "\r\n";
                            isInline = false;
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
                            isInline = true;
                            break;
                        case "li": //not doing ol li elements at this stage
                            outText.Write("\r\n*\t"); //using '*' as bullet char, with tab after, but whatever you want eg "\t->", if utf-8 0x2022
                            isInline = false;
                            break;
                        case "ul":
                            endElementString = "\r\n";
                            isInline = false;
                            break;
                        case "img": //inline-block in reality, but KISS
                            if (node.Attributes.Contains("alt"))
                            {
                                outText.Write('[' + node.Attributes["alt"].Value);
                                endElementString = "]";
                            }
                            if (node.Attributes.Contains("src"))
                            {
                                outText.Write('<' + node.Attributes["alt"].Value + '>');
                            }
                            isInline = true;
                            break;
                        case "span":
                        case "strong":
                        case "em":
                            isInline = true;
                            break;
                        default:
                            isInline = false;
                            break;
                    }
                    if (node.HasChildNodes)
                    {
                        ConvertContentTo(node, outText, isInline ? textInfo : new PreceedingDomTextInfo());
                        if (endElementString!=null)
                        {
                            outText.Write(endElementString);
                        }
                    }
                    break;
            }
        }
    }
    internal class PreceedingDomTextInfo
    {
        internal bool FirstTextOfBlockWritten {get;set;}
        internal bool LastCharWasSpace {get;set;}
        internal bool IsFirstElementOfDoc { get; set; }
    }
