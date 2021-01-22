    /// <summary>
    /// adds an element to an xml tree and builds the tree up if it is needed
    /// </summary>
    /// <param name="outerParent">root node</param>
    /// <param name="innerPath">root/childOne/innerParent/name</param>
    /// <param name="name">element to add</param>
    /// <param name="value">elements value</param>
    static XElement BuildTree(XElement outerParent, string innerParentPath, string name, object value)
    {
        List<string> s = innerParentPath.Split('/').ToList(); 
        string str = "";
        XElement prevInner = null;
        if (s.Count != 2)//use 2 since we know the root will always be there
        {
            var t = new List<string>(s);
            t.RemoveRange(s.Count - 1, 1);//remove last element
            string[] sa = t.ToArray();
            str = string.Join("/", sa);
            prevInner = BuildTree(outerParent, str, name, value);//call recursively till we get to root;
        }
        else
        {
            prevInner = outerParent;
        }
        XElement inner = prevInner.Element(s[s.Count - 1]);
        if (inner == null)
        {
            if (s[s.Count - 1] == name)//add actual element if we're at top lvl.
            {
                prevInner.Add(new XElement(name, value));
            }
            else
            {
                inner = new XElement(s[s.Count - 1]);
                prevInner.Add(inner);
            }
        }
        return inner;
    }
