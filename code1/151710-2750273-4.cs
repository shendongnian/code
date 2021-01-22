    using HtmlAgilityPack;
    public static class HtmlHelper {
        public static IList<HtmlLine> SplitIntoLines(this HtmlNode node, int wordsPerLine) {
            var lines = new List<HtmlLine>();
            
            var words = node.GetWords(node.ParentNode);
            
            for (int i = 0; i < words.Count; i += wordsPerLine) {
                lines.Add(new HtmlLine(words.Skip(i).Take(wordsPerLine)));
            }
            
            return lines.AsReadOnly();
        }
        
        public static IList<HtmlWord> GetWords(this HtmlNode node, HtmlNode top) {
            var words = new List<HtmlWord>();
            if (node.HasChildNodes) {
                foreach (var child in node.ChildNodes)
                    words.AddRange(child.GetWords(top));
            } else {
                var textNode = node as HtmlTextNode;
                if (textNode != null && !string.IsNullOrEmpty(textNode.Text)) {
                    string[] singleWords = textNode.Text.Split(
                        new string[] {" "},
                        StringSplitOptions.RemoveEmptyEntries
                    );
                    words.AddRange(
                        singleWords
                            .Select(w => new HtmlWord(w, node.ParentNode, top)
                        )
                    );
                }
            }
            
            return words.AsReadOnly();
        }
    }
