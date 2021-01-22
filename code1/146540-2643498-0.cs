    using System.Xml.Linq;
    using System.Xml.XPath;
    var xdoc = XDocument.Load(....);
    var nav = xdoc.CreateNavigator();
    foreach (repl in replacements) {
      var found = (XPathNodeIterator) nav.Evaluate("//@" + repl.OldName);
      while (found.MoveNext()) {
        var node = found.Current;
        var val = node.Value;
        node.DeleteSelf(); // Moves ref to parent.
        node.CreateAttribute("", repl.NewName, "", val);
      }
    }
