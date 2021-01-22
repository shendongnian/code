    static public IEnumerable<HistoryFieldChange> GetHistoryFieldChanges2(XDocument xdoc1, XDocument xdoc2)
    {
      string id = xdoc1.Descendants("Id").FirstOrDefault().Value;
      string name = xdoc1.Root.Name.ToString();
      IEnumerator<XElement> enumerator1 = xdoc1.Root.Elements().GetEnumerator();
      IEnumerator<XElement> enumerator2 = xdoc2.Root.Elements().GetEnumerator();
            
      for (; enumerator1.MoveNext() && enumerator2.MoveNext(); )
      {
        XElement element1 = enumerator1.Current;
        XElement element2 = enumerator2.Current;
        if (element1.Value != element2.Value)
        {
          HistoryFieldChange hfc = new HistoryFieldChange();
          hfc.EntityName = name;
          hfc.FieldName = element1.Name.ToString();
          hfc.KindOfChange = "fieldDataChange";
          hfc.ObjectReference = id;
          hfc.ValueBefore = element1.Value;
          hfc.ValueAfter = element2.Value;
          yield return hfc;
        }
      }
    }
