    public class XPathTag
    {
        public string XPath { get; set; }
    }
    // Populate the tag using the class. You could add a constructor
    // accepting the XPath if you wanted
    newListViewItem.Tag = new XPathTag { XPath  = FindXPath(node) };
    // Recover Tag property using a variable of type dynamic
    XPathTag tag = (XPathTag) myListView.Items[0].Tag;
    string xpath = tag.XPath;
