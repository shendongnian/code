    [Test]
    public void CompareXmlNodeLists()
    {
        // Arrange
        XmlDocument masterListRoot = new XmlDocument();
        masterListRoot.LoadXml(@"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <Mainnode>
                                    <Subnodes id=""1"">
                                    <SubChild>Child1</SubChild>
                                    </Subnodes>
                                    <Subnodes id=""2"">
                                    <SubChild>Child2</SubChild>
                                    </Subnodes>
                                    <Subnodes id=""3"">
                                    <SubChild>Child3</SubChild>
                                    </Subnodes>
                                </Mainnode>");
        XmlDocument subListRoot = new XmlDocument();
        subListRoot.LoadXml(@"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <Mainnode>
                                    <Subnodes id=""1"">
                                    <SubChild>Child1</SubChild>
                                    </Subnodes>
                                    <Subnodes id=""2"">
                                    <SubChild>Child2</SubChild>
                                    </Subnodes>
                                </Mainnode>");
        XmlNodeList subList = subListRoot.SelectSingleNode("Mainnode").SelectNodes("Subnodes");
        XmlNodeList masterList = masterListRoot.SelectSingleNode("Mainnode").SelectNodes("Subnodes");
        // Act
        var match = IsSubsetOf(masterList, subList);
        var multipleMactch = IsSubsetOf(new List<XmlNodeList> { masterList }, new List<XmlNodeList> { subList });
        //Assert
        Assert.True(match);
        Assert.True(multipleMactch);
    }
    public bool IsSubsetOf(List<XmlNodeList> masters, List<XmlNodeList> subs)
    {
        foreach (var sub in subs)
        {
            if (!masters.Any(x => IsSubsetOf(x, sub)))
            {
                return false;
            }
        }
        return true;
    }
    public bool IsSubsetOf(XmlNodeList master, XmlNodeList sub)
    {
        XNodeEqualityComparer comparer = new XNodeEqualityComparer();
        var xSub = sub.Cast<XmlNode>().Select(x => XDocument.Parse(x.OuterXml));
        var xMaster = master.Cast<XmlNode>().Select(x => XDocument.Parse(x.OuterXml)).ToList();
        foreach (var subItem in xSub)
        {
            if (!xMaster.Any(x => comparer.Equals(x, subItem)))
            {
                return false;
            }
        }
        return true;
    }
