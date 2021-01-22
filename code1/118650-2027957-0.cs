    for (int i = 0; i < xdoc1.Root.Elements().Count(); i++)
    {
      XElement element1 = xdoc1.Root.Elements().ElementAt(i);
      XElement element2 = xdoc2.Root.Elements().ElementAt(i);
    
      if (element1.Value != element2.Value)
      {
        HistoryFieldChange hfc = new HistoryFieldChange();
        hfc.EntityName = xdoc1.Root.Name.ToString();
        hfc.FieldName = element1.Name.ToString();
        hfc.KindOfChange = "fieldDataChange";
        hfc.ObjectReference = (xdoc1.Descendants("Id").FirstOrDefault()).Value;
        hfc.ValueBefore = element1.Value;
        hfc.ValueAfter = element2.Value;
        hfcList.Add(hfc);
      }
    }
