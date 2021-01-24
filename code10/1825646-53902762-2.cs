      class Program
        {
            static void Main(string[] args)
            {
                string html;
                string url = @"https://www.msn.com/en-gb/news/uknews/universal-credit-forcing-families-to-wait-months-for-help-to-pay-childcare-bills-mps-warn/ar-BBRjFtR?li=BBoPRmx";
                WebClient wc = new WebClient();
                HtmlDocument doc = new HtmlDocument();
    
                html = wc.DownloadString(url);
                doc.LoadHtml(html);
    
                HtmlNode nodeRoot = doc.DocumentNode.SelectSingleNode("//body");
                int level = 0;
    
                PrintRoot(nodeRoot, level);
            }
    
            static public void PrintRoot(HtmlNode node, int level)
            {
                PrintNode(node, level);
                Console.ReadLine();
            }
    
            private static bool EmptyString(string s)
            {
                return String.IsNullOrWhiteSpace(s);
            }
    
            static public void PrintNode(HtmlNode node, int level)
            {
                if (node.ChildNodes.Count > 0)
                {
                    foreach (HtmlNode child in node.ChildNodes)
                    {
                        PrintNode(child, level + 1); //<-- recursive
                    }
                }
                else
                {
                    //we have arrived a the node with no children
                    // check its siblings
                    HtmlNode sibling = node.NextSibling;
                    while (sibling != null)
                    {
                        if (sibling.NodeType == HtmlNodeType.Element)
                        {
                            var gg = sibling.Attributes.Where(attribute => attribute.Value.Contains("article")).ToList();
                            if (sibling.Attributes.Where(attribute => attribute.Value.Contains("article")).ToList().Count > 0)
                            {
                                List<string> potentialContent = Regex.Replace(sibling.OuterHtml, "<[^>]*>","").Split(' ').ToList();
                                potentialContent.RemoveAll(EmptyString);
    
                                string s = string.Join(" ", potentialContent);
     
                                Console.WriteLine(s); // here is where you get your string 
                                Console.ReadLine();
                            }
                        }
                        sibling = sibling.NextSibling;
                    }
                }
            }
        }
