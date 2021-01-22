    private bool IsParentOf(XmlNode parentNode, XmlNode node)
        {
            if (node.ParentNode == null) return false;
            return node.ParentNode == parentNode || IsParentOf(parentNode, node.ParentNode);
        }
        [TestMethod]
        public void TestMethod1()
        {
            string xml =
                    @"
                <MenuItem Name=""MenuItem 1"" Url=""MenuItem1.aspx""/>
                <MenuItem Name=""MenuItem 2"" Url=""MenuItem2.aspx"">
                    <MenuItem Name=""MenuItem 3"" Url=""MenuItem3.aspx"" />
                </MenuItem>
                <MenuItem Name=""MenuItem4"" Url=""MenuItem4.asp"" />";
            string url = "MenuItem3.aspx";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<MenuItems>" + xml + "</MenuItems>");
            var xPathFormat = "//MenuItem[@Url='{0}']";
            var currentNode = doc.SelectSingleNode(string.Format(xPathFormat, url));
            var menuItem1 = doc.SelectSingleNode(string.Format(xPathFormat, "MenuItem1.aspx"));
            Assert.IsFalse(IsParentOf(menuItem1, currentNode));
            var menuItem2 = doc.SelectSingleNode(string.Format(xPathFormat, "MenuItem2.aspx"));
            Assert.IsTrue(IsParentOf(menuItem2, currentNode));
        }
    
