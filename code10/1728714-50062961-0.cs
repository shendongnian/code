    public string str { get; private set; }
    private void RecursiveSearchInXmlWithString(XmlNode xmlnode, string nametofind)
        {
            // check if node has children, if so then it recursively search the children too
            if (xmlnode.HasChildNodes)
            {
                for (int i = 0; i < xmlnode.ChildNodes.Count; i++)
                {
                    RecursiveSearchInXmlWithString(xmlnode.ChildNodes[i], nametofind);
                }
            }
            // here is the element that we are searching for 
            if (xmlnode.Name == nametofind)
            {
                str = xmlnode.InnerText;
            }
        }
