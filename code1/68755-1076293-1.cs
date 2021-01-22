    /// <summary>Creates a new QName from a string with the format
    /// <c>prefix:local-name</c> or <c>local-name</c>.</summary>
    /// 
    /// <param name="qName">A QName string.</param>
    /// <param name="contextNode">An XML node from which to lookup the namespace
    /// prefix, or <c>null</c>.</param>
    /// 
    /// <exception cref="XmlInvalidPrefixException">Thrown if the prefix cannot be
    /// resolved from the lookup node. If <paramref name="contextNode"/> is
    /// <c>null</c>, then the only prefix that can be resolved is <c>xml</c>.
    /// </exception>
    public QName(String qName, XmlNode contextNode) {
