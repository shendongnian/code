    using HtmlAgilityPack;
    [Flags()]
    public enum NodeChange {
        None = 0,
        Dropped = 1,
        Added = 2
    }
    
    public class HtmlLine {
        private List<HtmlWord> _words;
        public IList<HtmlWord> Words {
            get { return _words.AsReadOnly(); }
        }
        
        public int WordCount {
            get { return _words.Count; }
        }
        
        public HtmlLine(IEnumerable<HtmlWord> words) {
            _words = new List<HtmlWord>(words);
        }
        
        private static NodeChange CompareNodeStacks(HtmlWord x, HtmlWord y, out HtmlNode[] droppedNodes, out HtmlNode[] addedNodes) {
            var droppedList = new List<HtmlNode>();
            var addedList = new List<HtmlNode>();
            
            // traverse x's NodeStack backwards to see which nodes
            // do not include y (and are therefore "finished")
            foreach (var node in x.NodeStack.Reverse()) {
                if (!Array.Exists(y.NodeStack, n => n.Equals(node)))
                    droppedList.Add(node);
            }
            
            // traverse y's NodeStack forwards to see which nodes
            // do not include x (and are therefore "new")
            foreach (var node in y.NodeStack) {
                if (!Array.Exists(x.NodeStack, n => n.Equals(node)))
                    addedList.Add(node);
            }
            
            droppedNodes = droppedList.ToArray();
            addedNodes = addedList.ToArray();
            
            NodeChange change = NodeChange.None;
            if (droppedNodes.Length > 0)
                change &= NodeChange.Dropped;
            if (addedNodes.Length > 0)
                change &= NodeChange.Added;
            
            // could maybe use this in some later revision?
            // not worth the effort right now...
            return change;
        }
        
        public override string ToString() {
            if (WordCount < 1)
                return string.Empty;
            
            var lineBuilder = new StringBuilder();
            
            using (var lineWriter = new StringWriter(lineBuilder))
            using (var xmlWriter = new XmlTextWriter(lineWriter)) {
                var firstWord = _words[0];
                foreach (var node in firstWord.NodeStack) {
                    xmlWriter.WriteStartElement(node.Name);
                    foreach (var attr in node.Attributes)
                        xmlWriter.WriteAttributeString(attr.Name, attr.Value);
                }
                xmlWriter.WriteString(firstWord.Text + " ");
                
                for (int i = 1; i < WordCount; ++i) {
                    var previousWord = _words[i - 1];
                    var word = _words[i];
                    
                    HtmlNode[] droppedNodes;
                    HtmlNode[] addedNodes;
                    
                    CompareNodeStacks(
                        previousWord,
                        word,
                        out droppedNodes,
                        out addedNodes
                    );
                    
                    foreach (var dropped in droppedNodes)
                        xmlWriter.WriteEndElement();
                    foreach (var added in addedNodes) {
                        xmlWriter.WriteStartElement(added.Name);
                        foreach (var attr in added.Attributes)
                            xmlWriter.WriteAttributeString(attr.Name, attr.Value);
                    }
                    
                    xmlWriter.WriteString(word.Text + " ");
                    
                    if (i == _words.Count - 1) {
                        foreach (var node in word.NodeStack)
                            xmlWriter.WriteEndElement();
                    }
                }
            }
            
            return lineBuilder.ToString();
        }
    }
