    public void RemoveAllNamespaces(ref XElement value)
    {
      List<XAttribute> attributesToRemove = new List<XAttribute>();
      foreach (void e_loopVariable in value.DescendantsAndSelf) {
        e = e_loopVariable;
        if (e.Name.Namespace != XNamespace.None) {
          e.Name = e.Name.LocalName;
        }
        foreach (void a_loopVariable in e.Attributes) {
          a = a_loopVariable;
          if (a.IsNamespaceDeclaration) {
            //do not keep it at all
            attributesToRemove.Add(a);
          } else if (a.Name.Namespace != XNamespace.None) {
            e.SetAttributeValue(a.Name.LocalName, a.Value);
            attributesToRemove.Add(a);
          }
        }
      }
      foreach (void a_loopVariable in attributesToRemove) {
        a = a_loopVariable;
        a.Remove();
      }
    }
