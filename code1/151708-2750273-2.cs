    using HtmlAgilityPack;
    public class HtmlWord {
        public string Text { get; private set; }
        public HtmlNode[] NodeStack { get; private set; }
        
        // convenience property to display list of ancestors cleanly
        // (for ease of debugging)
        public string NodeList {
            get { return string.Join(", ", NodeStack.Select(n => n.Name).ToArray()); }
        }
        
        internal HtmlWord(string text, HtmlNode node, HtmlNode top) {
            Text = text;
            NodeStack = GetNodeStack(node, top);
        }
        
        private static HtmlNode[] GetNodeStack(HtmlNode node, HtmlNode top) {
            var nodes = new Stack<HtmlNode>();
            
            while (node != null && !node.Equals(top)) {
                nodes.Push(node);
                node = node.ParentNode;
            };
            
            return nodes.ToArray();
        }
    }
