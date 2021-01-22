    static int GetNodePosition(XmlNode child)
    {
       for (int i=0; i<child.ParentNode.ChildNodes.Count; i++)
       {
           if (child.ParentNode.ChildNodes[i] == child)
           {
              // tricksy XPath, not starting its positions at 0 like a normal language
              return i + 1;
           }
       }
       throw new InvalidOperationException("Child node somehow not found in its parent's ChildNodes property.");
    }
