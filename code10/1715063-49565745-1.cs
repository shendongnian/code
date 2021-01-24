    public class XmlXPathDocument : XmlDocument
    {
        public const string XmlNamespaceUri = "http://www.w3.org/2000/xmlns/";
        public const string XmlNamespacePrefix = "xmlns";
        internal List<Tuple<string, string>> _discriminantAttributes = new List<Tuple<string, string>>();
        public XmlXPathDocument() => Construct();
        public XmlXPathDocument(XmlNameTable nameTable) : base(nameTable) => Construct();
        public XmlXPathDocument(XmlImplementation implementation) : base(implementation) => Construct();
        protected virtual void Construct() => XPathNamespaceManager = new XmlNamespaceManager(new NameTable());
        public virtual XmlNamespaceManager XPathNamespaceManager { get; private set; }
        public override XmlElement CreateElement(string prefix, string localName, string namespaceURI) => new XmlXPathElement(prefix, localName, namespaceURI, this);
        public override XmlCDataSection CreateCDataSection(string data) => new XmlXPathCDataSection(data, this);
        public override XmlText CreateTextNode(string text) => new XmlXPathText(text, this);
        public virtual void AddDiscriminantAttribute(string name, string namespaceURI)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            _discriminantAttributes.Add(new Tuple<string, string>(name, namespaceURI));
        }
        public virtual bool IsDiscriminant(XmlAttribute attribute)
        {
            if (attribute == null)
                throw new ArgumentNullException(nameof(attribute));
            foreach (var pair in _discriminantAttributes)
            {
                string ns = Nullify(attribute.NamespaceURI);
                string dns = Nullify(pair.Item2);
                if (ns == dns && pair.Item1 == attribute.LocalName)
                    return true;
            }
            return false;
        }
        private static string Nullify(string text)
        {
            if (text == null)
                return null;
            text = text.Trim();
            if (text.Length == 0)
                return null;
            return text;
        }
        internal string GetPrefix(string namespaceURI)
        {
            if (string.IsNullOrEmpty(namespaceURI))
                return null;
            string prefix = XPathNamespaceManager.LookupPrefix(namespaceURI);
            if (!string.IsNullOrEmpty(prefix))
            {
                XPathNamespaceManager.AddNamespace(prefix, namespaceURI);
                return prefix;
            }
            string newPrefix;
            int index = 0;
            do
            {
                newPrefix = "ns" + index;
                if (XPathNamespaceManager.LookupNamespace(newPrefix) == null)
                    break;
                index++;
            }
            while (true);
            XPathNamespaceManager.AddNamespace(newPrefix, namespaceURI);
            return newPrefix;
        }
        private static bool IsNamespaceAttribute(XmlAttribute attribute)
        {
            if (attribute == null)
                return false;
            return attribute.NamespaceURI == XmlNamespaceUri && attribute.Prefix == XmlNamespacePrefix;
        }
        private static IEnumerable<XmlAttribute> GetAttributes(IXmlXPathNode node)
        {
            var xe = node as XmlElement;
            if (xe == null)
                yield break;
            foreach (XmlAttribute att in xe.Attributes)
            {
                yield return att;
            }
        }
        private static XmlAttribute GetAttribute(IXmlXPathNode node, string name) => node is XmlElement xe ? xe.Attributes[name] : null;
        private static XmlAttribute GetAttribute(IXmlXPathNode node, string localName, string ns) => node is XmlElement xe ? xe.Attributes[localName, ns] : null;
        public virtual bool InjectXml(XmlDocument target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));
            if (DocumentElement == null)
                return false;
            bool changed = false;
            foreach (XmlNode node in SelectNodes("//node()"))
            {
                var xelement = node as IXmlXPathNode;
                if (xelement == null)
                    continue;
                if (string.IsNullOrEmpty(xelement.XPathExpression))
                    continue;
                XmlNode other = target.SelectSingleNode(xelement.XPathExpression, XPathNamespaceManager);
                if (other != null)
                {
                    if (other is XmlElement otherElement)
                    {
                        foreach (XmlAttribute att in GetAttributes(xelement))
                        {
                            if (IsNamespaceAttribute(att))
                                continue;
                            if (otherElement.Attributes[att.LocalName, att.NamespaceURI]?.Value != att.Value)
                            {
                                otherElement.SetAttribute(att.LocalName, att.NamespaceURI, att.Value);
                                changed = true;
                            }
                        }
                        continue;
                    }
                }
                if (node is XmlXPathElement element)
                {
                    XmlElement parent = EnsureTargetParent(xelement, target, out changed);
                    XmlElement targetElement = target.CreateElement(element.LocalName, element.NamespaceURI);
                    changed = true;
                    if (parent == null)
                    {
                        target.AppendChild(targetElement);
                    }
                    else
                    {
                        parent.AppendChild(targetElement);
                    }
                    foreach (XmlAttribute att in GetAttributes(xelement))
                    {
                        if (IsNamespaceAttribute(att))
                            continue;
                        targetElement.SetAttribute(att.LocalName, att.NamespaceURI, att.Value);
                    }
                    continue;
                }
                if (node is XmlXPathCDataSection cdata)
                {
                    XmlElement parent = EnsureTargetParent(xelement, target, out changed);
                    var targetCData = target.CreateCDataSection(cdata.Value);
                    changed = true;
                    if (parent == null)
                    {
                        target.AppendChild(targetCData);
                        AppendNextTexts(node, targetCData, target);
                    }
                    else
                    {
                        if (parent.ChildNodes.Count == 1 && parent.ChildNodes[0] is XmlCharacterData)
                        {
                            parent.RemoveChild(parent.ChildNodes[0]);
                        }
                        parent.AppendChild(targetCData);
                        AppendNextTexts(node, targetCData, parent);
                    }
                    continue;
                }
                if (node is XmlXPathText text)
                {
                    XmlElement parent = EnsureTargetParent(xelement, target, out changed);
                    var targetText = target.CreateTextNode(text.Value);
                    changed = true;
                    if (parent == null)
                    {
                        target.AppendChild(targetText);
                        AppendNextTexts(node, targetText, target);
                    }
                    else
                    {
                        if (parent.ChildNodes.Count == 1 && parent.ChildNodes[0] is XmlCharacterData)
                        {
                            parent.RemoveChild(parent.ChildNodes[0]);
                        }
                        parent.AppendChild(targetText);
                        AppendNextTexts(node, targetText, parent);
                    }
                    continue;
                }
            }
            return changed;
        }
        private static void AppendNextTexts(XmlNode textNode, XmlNode targetTextNode, XmlNode parent)
        {
            do
            {
                if (textNode.NextSibling is XmlText text)
                {
                    var newText = targetTextNode.OwnerDocument.CreateTextNode(text.Value);
                    parent.AppendChild(newText);
                }
                else
                {
                    var cdata = textNode.NextSibling as XmlCDataSection;
                    if (cdata == null)
                        break;
                    var newCData = targetTextNode.OwnerDocument.CreateCDataSection(cdata.Value);
                    parent.AppendChild(newCData);
                }
                textNode = textNode.NextSibling;
            }
            while (true);
        }
        private static XmlElement EnsureTargetParent(IXmlXPathNode element, XmlDocument target, out bool changed)
        {
            changed = false;
            if (element.ParentNode is XmlXPathElement parent)
            {
                if (string.IsNullOrEmpty(parent.XPathExpression))
                    return null;
                if (target.SelectSingleNode(parent.XPathExpression, element.OwnerDocument.XPathNamespaceManager) is XmlElement targetElement)
                    return targetElement;
                var parentElement = EnsureTargetParent(parent, target, out changed);
                targetElement = target.CreateElement(parent.LocalName, parent.NamespaceURI);
                parentElement.AppendChild(targetElement);
                changed = true;
                return targetElement;
            }
            return target.DocumentElement;
        }
    }
    public class XmlXPathElement : XmlElement, IXmlXPathNode
    {
        private Lazy<string> _xPathExpression;
        public XmlXPathElement(string prefix, string localName, string namespaceURI, XmlXPathDocument doc) : base(prefix, localName, namespaceURI, doc)
        {
            _xPathExpression = new Lazy<string>(() => GetXPathExpression());
        }
        public new XmlXPathDocument OwnerDocument => (XmlXPathDocument)base.OwnerDocument;
        public virtual string XPathExpression => _xPathExpression.Value;
        private static string GetAttEscapedValue(string value)
        {
            if (value.IndexOf('\'') >= 0)
                return "=\"" + value.Replace("\"", "&quot;") + "\"";
            return "='" + value + "'";
        }
        private string GetDiscriminantAttributeXPath()
        {
            foreach (var att in OwnerDocument._discriminantAttributes)
            {
                XmlAttribute disc;
                if (string.IsNullOrEmpty(att.Item2))
                {
                    disc = GetAttributeNode(att.Item1);
                }
                else
                {
                    disc = GetAttributeNode(att.Item1, att.Item2);
                }
                if (disc != null)
                {
                    string newPrefix = OwnerDocument.GetPrefix(NamespaceURI);
                    string name = Name + "[@" + disc.Name + GetAttEscapedValue(disc.Value) + "]";
                    if (newPrefix != null)
                    {
                        name = newPrefix + ":" + name;
                    }
                    return name;
                }
            }
            return null;
        }
        private string GetAttributesXPath()
        {
            if (Attributes.Count == 0)
                return null;
            var sb = new StringBuilder();
            foreach (XmlAttribute att in Attributes)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }
                sb.Append("@");
                sb.Append(att.Name);
                sb.Append(GetAttEscapedValue(att.Value));
                OwnerDocument.GetPrefix(att.NamespaceURI);
            }
            var text = sb.ToString().Trim();
            if (text.Length == 0)
                return null;
            return "[" + text + "]";
        }
        private string GetXPath(XmlNodeList parentNodes)
        {
            string discriminant = GetDiscriminantAttributeXPath();
            if (discriminant != null)
                return discriminant;
            string name = Name;
            string newPrefix = OwnerDocument.GetPrefix(NamespaceURI);
            if (newPrefix != null)
            {
                name = newPrefix + ":" + LocalName;
            }
            if (parentNodes.Count == 1)
                return name;
            var sameName = new List<XmlElement>();
            foreach (XmlNode node in parentNodes)
            {
                if (node.NodeType != XmlNodeType.Element)
                    continue;
                if (node.Name == Name)
                {
                    sameName.Add((XmlElement)node);
                }
            }
            if (sameName.Count == 1)
                return name;
            string byIndex = null;
            var sameAtts = new List<XmlElement>();
            for (int i = 0; i < sameName.Count; i++)
            {
                if (sameName[i] == this)
                {
                    byIndex = name + "[" + (i + 1) + "]";
                    continue;
                }
                bool same = true;
                foreach (XmlAttribute att in Attributes)
                {
                    XmlAttribute sameAtt = sameName[i].Attributes[att.LocalName, att.NamespaceURI];
                    if (sameAtt == null || string.Compare(sameAtt.Value, att.Value, StringComparison.OrdinalIgnoreCase) != 0)
                    {
                        same = false;
                        break;
                    }
                }
                if (same)
                {
                    sameAtts.Add(sameName[i]);
                }
            }
            if (sameAtts.Count == 0)
                return name + GetAttributesXPath();
            return byIndex;
        }
        private string GetXPathExpression()
        {
            if (ParentNode == null)
            {
                string name = Name;
                string newPrefix = OwnerDocument.GetPrefix(NamespaceURI);
                if (newPrefix != null)
                {
                    name = newPrefix + ":" + name;
                }
                return name;
            }
            string expr = GetXPath(ParentNode.ChildNodes);
            if (ParentNode is XmlXPathElement parent)
            {
                expr = parent.XPathExpression + "/" + expr;
            }
            if (ParentNode.NodeType == XmlNodeType.Document)
            {
                expr = "/" + expr;
            }
            return expr;
        }
    }
    public class XmlXPathText : XmlText, IXmlXPathNode
    {
        private Lazy<string> _xPathExpression;
        public XmlXPathText(string data, XmlXPathDocument doc) : base(data, doc)
        {
            _xPathExpression = new Lazy<string>(() => GetTextXPathExpression(this));
        }
        public new XmlXPathDocument OwnerDocument => (XmlXPathDocument)base.OwnerDocument;
        public virtual string XPathExpression => _xPathExpression.Value;
        internal static string GetTextXPathExpression(XmlNode node)
        {
            if (node.ParentNode is IXmlXPathNode element)
                return element.XPathExpression + "/text()";
            return null;
        }
    }
    public class XmlXPathCDataSection : XmlCDataSection, IXmlXPathNode
    {
        private Lazy<string> _xPathExpression;
        public XmlXPathCDataSection(string data, XmlXPathDocument doc) : base(data, doc)
        {
            _xPathExpression = new Lazy<string>(() => XmlXPathText.GetTextXPathExpression(this));
        }
        public new XmlXPathDocument OwnerDocument => (XmlXPathDocument)base.OwnerDocument;
        public virtual string XPathExpression => _xPathExpression.Value;
    }
    public interface IXmlXPathNode
    {
        string XPathExpression { get; }
        XmlNode ParentNode { get; }
        XmlXPathDocument OwnerDocument { get; }
    }
