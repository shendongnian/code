var declarations = root.Attributes().Where(a => a.IsNamespaceDeclaration);
foreach (var attr in declarations)
{
    // attr.LocalName is the prefix
    // attr.Namespace is "xmlns"
    // attr.Value is namespace URI
}
